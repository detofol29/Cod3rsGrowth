﻿using System;
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
       return filmes.FirstOrDefault(a => a.Id == id);
    }

    public static List<Filme> RetornarListaDeFilmesMock()
    {
        return new List<Filme>();
    }
}