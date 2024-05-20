using Cod3rsGrowth.Servicos.Interfaces;
using System;
using Cod3rsGrowth.Dominio;
using System.Linq;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeServico
{
    List<Ator> IFilmeServico.ObterAtoresDoFilme(Filme filme)
    {
        var list = new List<Ator>();
        foreach(var ator in filme.Atores)
        {
            list.Add(ator);
        }
        return list;
    }
}