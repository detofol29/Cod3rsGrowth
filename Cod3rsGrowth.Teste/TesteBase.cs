using Microsoft.Extensions.DependencyInjection;

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