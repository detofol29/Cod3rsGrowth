﻿using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IFilmeRepositorio
{
    Filme ObterPorId(int id);
    List<Filme> ObterTodos(FiltroFilme? FiltroFilme);
    void Inserir(Filme filme);
    public void Remover(int id);
    public void Editar(Filme filme);
}