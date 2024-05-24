using System;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;

namespace Cod3rsGrowth.Teste;

public class FilmeRepositorioMock : IFilmeRepositorio
{
    private readonly TabelasSingleton tabelasSingleton;

    public FilmeRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.Instance;
    }

    public Filme ObterPorId(int id)
    {
        return tabelasSingleton.Filmes.FirstOrDefault(a => a.Id == id);
    }

    public List<Filme> ObterTodos() 
    {
        return tabelasSingleton.Filmes;
    }

    public void Adicionar(Filme filme)
    {
        tabelasSingleton.Filmes.Add(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        if(filme != null)
        {
            tabelasSingleton.Filmes.Remove(filme);
        }
    }
}