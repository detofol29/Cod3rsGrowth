using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;

namespace Cod3rsGrowth.Infra
{
    public class ModuloInjetorInfra
    {
        private static string _stringDeConexao = "StreamingFilmesBD";

        private static string _chaveDeConexao = ConfigurationManager.ConnectionStrings[_stringDeConexao].ConnectionString;
        public static void AdquirirServicos(IServiceCollection services)
        {
            var chave = Encoding.ASCII.GetBytes(Configuracao.Secret);
            services.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            services.AddScoped<IAtorRepositorio, AtorRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<UsuarioServicos>();
            services.AddScoped<FilmeServicos>();
            services.AddScoped<AtorServicos>();
            services.AddScoped<UsuarioRepositorio>();
            services.AddScoped<IValidator<Filme>, FilmeValidacao>();
            services.AddScoped<IValidator<Ator>, AtorValidacao>();
            services.AddScoped<IValidator<Usuario>, UsuarioValidacao>();
            services.AddLinqToDBContext<ConexaoDados>((provider, options) => options.UseSqlServer(ConfigurationManager.ConnectionStrings[_stringDeConexao].ConnectionString));
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
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb
                        .AddSqlServer()
                        .WithGlobalConnectionString(_chaveDeConexao)
                        .ScanIn(typeof(Migracao20240705001230_CriaTabelaUsuarios_Filmes_Atores).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}