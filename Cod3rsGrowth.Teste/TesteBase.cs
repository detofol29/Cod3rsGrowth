using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Teste
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider { get; set; }

        public TesteBase()
        {
            var service = new ServiceCollection();
            ModuloInjecao.ImplementarServico(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }

        
    }
}
