using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using static LinqToDB.Common.Configuration;
namespace Cod3rsGrowth.Forms;

 class Program
{
    private static string _stringDeConexao = "StreamingFilmesBD";
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
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
            // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                // Add SQLite support to FluentMigrator
                .AddSqlServer()
                // Set the connection string
                .WithGlobalConnectionString("Data Source=DESKTOP-G0T9JPL\\SQLEXPRESS;Initial Catalog=Cod3rsGrowth;User ID=sa;Password=sap@123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                // Define the assembly containing the migrations
                //.ScanIn(typeof(Migracao20240621501000_CriaTabelaAtores).Assembly).For.Migrations()
                //.ScanIn(typeof(Migracao20240621401000_CriaTabelaFilmes).Assembly).For.Migrations()
                //.ScanIn(typeof(Migracao20240621001100_CriaTabelaUsuarios).Assembly).For.Migrations())
                .ScanIn(typeof(Migracao20240624002100_AdicionaChaveEstrangeira).Assembly).For.Migrations())
            // Enable logging to console in the FluentMigrator way
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            // Build the service provider
            .BuildServiceProvider(false);
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp(20240624002100);
    }
}