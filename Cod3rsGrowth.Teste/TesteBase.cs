using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Cod3rsGrowth.Dominio;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Servicos.Interfaces;

namespace Cod3rsGrowth.Teste;

public class TesteBase : IDisposable
{
    protected readonly ServiceProvider serviceProvider;
    
    public TesteBase()
    {
        var services = new ServiceCollection();
        ModuloInjetor.ObterServicosParaServiceCollection(services);
        serviceProvider = services.BuildServiceProvider();
    }
    


    public void Dispose()
    {
        serviceProvider.Dispose(); 
    }
}