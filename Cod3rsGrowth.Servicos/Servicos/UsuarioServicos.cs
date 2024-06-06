﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Servicos.Servicos;

public class UsuarioServicos : IUsuarioRepositorio
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    public UsuarioServicos(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }
    
    public List<Usuario> ObterTodos()
    {
        return _usuarioRepositorio.ObterTodos();
    }

    public Usuario ObterPorId(int id)
    {
        return _usuarioRepositorio.ObterPorId(id);
    }

    public void Inserir(Usuario usuario)
    {
        _usuarioRepositorio.Inserir(usuario);
    }

    public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
    {
        usuario.MinhaLista.Add(filme);
    }

    public void Logar(string nick, string senha)
    {
    }

    public void Deslogar(Usuario usuario)
    {
    }

    public void LicenciarFilmePorUsuario(Usuario usuario)
    {
    }
}