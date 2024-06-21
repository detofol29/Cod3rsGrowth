using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.RepositoriosMock;
using FluentValidation;
using Cod3rsGrowth.Servicos.Validacoes;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste;
public static class ModuloInjetor
{
    public static void ObterServicosParaServiceCollection(ServiceCollection services)
    {
        services.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
        services.AddScoped<IAtorRepositorio, AtorRepositorio>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddScoped<UsuarioServicos>();
        services.AddScoped<FilmeServicos>();
        services.AddScoped<AtorServicos>();
        services.AddScoped<IValidator<Filme>, FilmeValidacao>();
        services.AddScoped<IValidator<Ator>, AtorValidacao>();
        services.AddScoped<IValidator<Usuario>, UsuarioValidacao>();
    }
}