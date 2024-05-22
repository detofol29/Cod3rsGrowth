using Cod3rsGrowth.Servicos.Interfaces;
using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos;

public class UsuarioServicos : IUsuarioServicos
{
    public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
    {
        usuario.MinhaLista.Add(filme);
    }

    public void Logar(Usuario usuario)
    {

    }

    public void Deslogar(Usuario usuario)
    {

    }
}