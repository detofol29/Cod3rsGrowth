using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Dominio;
using Microsoft.Extensions.DependencyInjection;
using System;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Teste;
public static class ModuloInjetor
{
    public static void ObterServicosParaServiceCollection(ServiceCollection services)
    {
        services.AddScoped<IAtorServico, AtorServicos>();
    }
}
