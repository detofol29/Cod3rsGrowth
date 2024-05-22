using Cod3rsGrowth.Servicos.Interfaces;
using System;
using System.Linq;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeServico
{
    public List<Ator> ObterAtoresDoFilme(Filme filme)
    {
        var list = new List<Ator>();
        foreach(var ator in filme.Atores)
        {
            list.Add(ator);
        }
        return list;
    }

    public static bool VerificarDisponibilidadeDoFilme(Usuario usuario,Filme filme)
    {
        bool disponivelNoPlano;

        if (usuario.Plano == PlanoEnum.Premium)
        {
             disponivelNoPlano = true;
        }    
        else if (usuario.Plano == PlanoEnum.Nerd && filme.Genero == GeneroEnum.Ficcao || filme.Genero == GeneroEnum.fantasia)
        {    
             disponivelNoPlano = true;
        }    
        else if (usuario.Plano == PlanoEnum.Kids && filme.Classificacao == ClassificacaoIndicativa.livre)
        {    
             disponivelNoPlano = true;
        }    
        else if (usuario.Plano == PlanoEnum.Free && filme.Genero == GeneroEnum.Comedia)
        {    
             disponivelNoPlano = true;
        }    
        else 
        {    
             disponivelNoPlano = false;
        }
        return disponivelNoPlano;
    }
}