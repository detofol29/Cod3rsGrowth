using System;
using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Dominio;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Teste;
public static class ModuloInjetor
{
    public static void ObterServicosParaServiceCollection(ServiceCollection services)
    {
        services.AddScoped<IAtorServico, AtorServicos>();
        services.AddScoped<IFilmeRepositorio, FilmeRepositorioMock>();
    }
}
