using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IRepositorio <T> where T : class 
{
    T ObterPorId(int id);

    List<T> ObterTodos();
}