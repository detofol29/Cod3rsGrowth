using System;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Servicos.Interfaces;

public interface IFilmeServico
{
    List<Ator> ObterAtoresDoFilme(Filme filme);
}
