using Cod3rsGrowth.Dominio.Interfaces;
using System;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class UsuarioServicos : IUsuarioServicos
    {
        public void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario)
        {
            usuario.MinhaLista.Add(filme);
        }
    }
}