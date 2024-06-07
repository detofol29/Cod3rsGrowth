﻿using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IUsuarioRepositorio  
{
    Usuario ObterPorId(int id);
    void Inserir(Usuario usuario);
    List<Usuario> ObterTodos();
}