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
    private readonly TabelaFilme _tabelaFilme;

    public FilmeRepositorioMock()
    {
        _tabelaFilme = TabelaFilme.Instance;
    }

    public Filme ObterPorId(int id)
    {
        return _tabelaFilme.Filmes.FirstOrDefault(a => a.Id == id);
    }

    public List<Filme> ObterTodos() 
    {
        return _tabelaFilme.Filmes;
    }
}