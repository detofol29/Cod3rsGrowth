using System;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Infra;

public interface IFilmeRepositorio
{
    Filme ObterPorId(int id, List<Filme> filmes); 
}