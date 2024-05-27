using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Interfaces;

public interface IFilmeServico
{
    List<Ator> ObterAtoresDoFilme(Filme filme);
}