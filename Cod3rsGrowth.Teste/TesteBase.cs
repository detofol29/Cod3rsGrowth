using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Cod3rsGrowth.Dominio;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;

namespace Cod3rsGrowth.Teste;

public class TesteBase : IDisposable
{
    protected readonly ServiceProvider serviceProvider;
    
    public TesteBase()
    {
        var services = new ServiceCollection();
        Configurar(services);
        serviceProvider = services.BuildServiceProvider();
    }
    public static void Configurar(ServiceCollection services)
    {
        services.AddScoped<IAtorServico, AtorServicos>();
    }


    public void Dispose()
    {
        serviceProvider.Dispose(); 
    }
}