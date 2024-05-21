using System;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste;

public class FilmeRepositorioMock : IFilmeRepositorio
{
    public Filme ObterPorId(int id, List<Filme> filmes)
    {
       var filme = filmes.FirstOrDefault(a => a.Id == id);
       return filme;
    }

    public List<Filme> RetornarListaDeFilmesMock()
    {
        var filmes = new List<Filme>()
        {
            new Filme() {Id = 1, Titulo = "Star Wars"},
            new Filme() {Id = 2, Titulo = "Star Track"},
            new Filme() {Id = 3, Titulo = "Star Top"}
        };
        return filmes;
    }
}