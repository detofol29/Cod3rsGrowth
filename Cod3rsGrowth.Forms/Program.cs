using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentMigrator.Runner;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Cod3rsGrowth.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

        using (var serviceProvider = CreateServices())
        using (var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }
    }

    private static ServiceProvider CreateServices()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString("Data Source=DESKTOP-G0T9JPL\\SQLEXPRESS;Initial Catalog=Cod3rsGrowth;User ID=sa;Password=sap@123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .ScanIn(typeof(Migracao20240626001100_CriaTabelaUsuarios).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao20240626401000_CriaTabelaFilmes).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao20240626501000_CriaTabelaAtores).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao20240627002100_AdicionaChaveEstrangeira).Assembly).For.Migrations()
                .ScanIn(typeof(Migracao20240627002200_CriaTabelaFilmesDoUsuario).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp(20240627002200);
    }
}