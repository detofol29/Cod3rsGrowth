using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Dominio;
using System;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class UsuarioServicos : IUsuarioServicos
    {
        public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
        {
            usuario.MinhaLista.Add(filme);
        }
    }
}