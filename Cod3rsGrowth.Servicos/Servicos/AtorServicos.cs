using Cod3rsGrowth.Servicos.Interfaces;
using Cod3rsGrowth.Dominio;
using System;


namespace Cod3rsGrowth.Servicos.Servicos;

public class AtorServicos : IAtorServico
{
    public List<string> ObterPremiosDoAtor(Ator ator)
    {
        var list = new List<string>();
        foreach (var premio in ator.Premios)
        {
            list.Add(premio);
        }
        return list;
    }
}