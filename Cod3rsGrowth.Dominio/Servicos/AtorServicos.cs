using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth_Domínio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Servicos;

public class AtorServicos : IAtorServico
{
    public readonly IAtor ator;
    public AtorServicos(IAtor _ator)
    {
        ator = _ator;
    }

    List<string> IAtorServico.ObterPremiosDoAtor()
    {
        var list = new List<string>();
        foreach (var premio in ator.Premios)
        {
            list.Add(premio);
        }
        return list;
    }

}
