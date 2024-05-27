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
    private readonly List<Filme> tabelasSingleton;

    public FilmeRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstacniaFilmes;
    }

    public Filme ObterPorId(int id)
    {
        return tabelasSingleton.FirstOrDefault(a => a.Id == id);
    }

    public List<Filme> ObterTodos() 
    {
        return tabelasSingleton;
    }

    public void Adicionar(Filme filme)
    {
        tabelasSingleton.Add(filme);
    }

    public void Remover(int id)
    {
        tabelasSingleton.Remove(ObterPorId(id) ?? null);
    }
}