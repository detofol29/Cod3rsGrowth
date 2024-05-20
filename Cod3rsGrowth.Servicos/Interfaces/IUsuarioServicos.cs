using System;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Servicos.Interfaces;

public interface IUsuarioServicos
{
    void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario);
}