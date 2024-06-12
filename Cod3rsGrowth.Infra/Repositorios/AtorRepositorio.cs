﻿using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class AtorRepositorio : IAtorRepositorio
{
    private readonly List<Ator> tabelaAtor;
    public Ator ObterPorId(int id)
    {
        return tabelaAtor.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Id nao encontrado");
    }

    public List<Ator> ObterTodos()
    {
        return tabelaAtor;
    }

    public void Inserir(Ator ator)
    {
        tabelaAtor.Add(ator);
    }

    public void Adicionar(Ator ator)
    {
        tabelaAtor.Add(ator);
    }

    public void Remover(int id)
    {
        var ator = ObterPorId(id);
        tabelaAtor.Remove(ator);
    }

    public void Ordenar()
    {
        tabelaAtor.OrderBy(n => n.Id);
    }
}