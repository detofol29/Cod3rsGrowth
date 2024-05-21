using Cod3rsGrowth.Servicos.Interfaces;
using System;
using System.Linq;
using Cod3rsGrowth.Dominio.Modelos;

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