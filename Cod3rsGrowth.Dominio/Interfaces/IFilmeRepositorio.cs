﻿using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation.Results;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IFilmeRepositorio
{
    Filme ObterPorId(int id);
    List<Filme> ObterTodos();
    void Inserir(Filme filme);
    public void Remover(int id);
    public void Editar(int id, Filme filme);
}