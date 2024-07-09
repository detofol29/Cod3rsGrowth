using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using Cod3rsGrowth.web.Controllers;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
namespace Cod3rsGrowth.Forms;

class Program
{
    private static string _stringDeConexao = "StreamingFilmesBD";
    [STAThread]
    static void Main()
    {
        using (var serviceProvider = CreateServices())
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }

        var host = CreateHostBuilder().Build();
        var ServiceProvider = host.Services;
        
        ApplicationConfiguration.Initialize();

        Application.Run(new FormAutenticacao(ServiceProvider.GetRequiredService<UsuarioServicos>(), ServiceProvider.GetRequiredService<FilmeServicos>(),
          ServiceProvider.GetRequiredService<UsuarioRepositorio>()));
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            services.AddScoped<IAtorRepositorio, AtorRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<UsuarioServicos>();
            services.AddScoped<FilmeServicos>();
            services.AddScoped<AtorServicos>();
            services.AddScoped<UsuarioRepositorio>();
            services.AddScoped<LoginControlador>();
            services.AddScoped<IValidator<Filme>, FilmeValidacao>();
            services.AddScoped<IValidator<Ator>, AtorValidacao>();
            services.AddScoped<IValidator<Usuario>, UsuarioValidacao>();
            services.AddScoped<FormListaFilme>();
            services.AddScoped<FormAutenticacao>();
            services.AddLinqToDBContext<ConexaoDados>((provider, options) => options.UseSqlServer(ConfigurationManager.ConnectionStrings[_stringDeConexao].ConnectionString));

            //------------Servico de autenticação---------

            services.AddCors();
            services.AddControllers();
            var key = Encoding.ASCII.GetBytes(Configuracao.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMvc();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static ServiceProvider CreateServices()
    {
        string stringDeConexao = ConfigurationManager.ConnectionStrings[_stringDeConexao].ConnectionString;
        var colecao =  new ServiceCollection()
            .AddLinqToDBContext<ConexaoDados>((provider, options) => options.UseSqlServer(ConfigurationManager.ConnectionStrings[_stringDeConexao].ConnectionString).UseDefaultLogging(provider))
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(Migracao20240705001230_CriaTabelaUsuarios_Filmes_Atores).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        return colecao;
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp(20240705001230);
    }
}