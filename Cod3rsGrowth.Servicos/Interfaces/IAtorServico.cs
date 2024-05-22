using Cod3rsGrowth.Dominio.Modelos;
using System;

namespace Cod3rsGrowth.Servicos.Interfaces;

public interface IAtorServico
{
    List<string> ObterPremiosDoAtor(Ator ator);
}