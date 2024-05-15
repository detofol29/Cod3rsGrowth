using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Cod3rsGrowth_Dominio;

namespace Cod3rsGrowth.Teste
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider { get; set; }

        // Metodo herdado da interface IDisposable 
        public void Dispose()
        {
            
        }
    }
}
