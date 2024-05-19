using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Servicos;

public class AtorServicos : IAtorServico
{
    List<string> IAtorServico.ObterPremiosDoAtor(Ator ator)
    {
        var list = new List<string>();
        foreach (var premio in ator.Premios)
        {
            list.Add(premio);
        }
        return list;
    }
}