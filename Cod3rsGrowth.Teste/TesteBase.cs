using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Cod3rsGrowth.Dominio;
using System.Runtime.CompilerServices;

namespace Cod3rsGrowth.Teste
{
    public class TesteBase : IDisposable
    {
        protected readonly ServiceProvider ServiceProvider;

        public TesteBase()
        {
            ServiceProvider = ModuloInjecao.Configure();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }

        
    }
}
