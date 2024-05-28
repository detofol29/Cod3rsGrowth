using Cod3rsGrowth.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste;
public static class ModuloInjetor
{
    public static void ObterServicosParaServiceCollection(ServiceCollection services)
    {
        services.AddScoped<IAtorServico, AtorServicos>();
        services.AddScoped<IRepositorio<Filme>, FilmeRepositorioMock>();
        services.AddScoped<IRepositorio<Ator>, AtorRepositorioMock>();
        services.AddScoped<IRepositorio<Usuario>, UsuarioRepositorioMock>();
    }
}