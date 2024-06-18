using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.RepositoriosMock;
using FluentValidation;
using Cod3rsGrowth.Servicos.Validacoes;

namespace Cod3rsGrowth.Teste;
public static class ModuloInjetor
{
    public static void ObterServicosParaServiceCollection(ServiceCollection services)
    {
        services.AddScoped<IFilmeRepositorio, FilmeRepositorioMock>();
        services.AddScoped<IAtorRepositorio, AtorRepositorioMock>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioMock>();
        services.AddScoped<UsuarioServicos>();
        services.AddScoped<FilmeServicos>();
        services.AddScoped<AtorServicos>();
        services.AddScoped<IValidator<Filme>, FilmeValidacao>();
        services.AddScoped<IValidator<Ator>, AtorValidacao>();
        services.AddScoped<IValidator<Usuario>, UsuarioValidacao>();
    }
}