using System;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste;

public class FilmeRepositorioMock : IFilmeRepositorio
{
    public Filme ObterPorId(int id)
    {
       throw new NotImplementedException();
    }

    public List<Filme> ObterTodos() 
    {
        return new List<Filme>();
    }
}