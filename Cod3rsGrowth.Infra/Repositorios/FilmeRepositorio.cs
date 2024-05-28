using Cod3rsGrowth.Infra.Interfaces;
using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class FilmeRepositorio : IFilmeRepositorio
{
    private readonly List<Filme> tabelaFilme;
    public Filme ObterPorId(int id)
    {
        return tabelaFilme.FirstOrDefault(a => a.Id == id);
    }

    public List<Filme> ObterTodos()
    {
        return tabelaFilme;
    }

    public void Adicionar(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        if (filme != null)
        {
            tabelaFilme.Remove(filme);
        }
    }
}