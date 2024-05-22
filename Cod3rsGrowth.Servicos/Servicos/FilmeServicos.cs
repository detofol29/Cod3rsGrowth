using Cod3rsGrowth.Servicos.Interfaces;
using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeServico
{
    public List<Ator> ObterAtoresDoFilme(Filme filme)
    {
        return filme.Atores;
    }

    public static bool VerificarDisponibilidadeDoFilme(Usuario usuario, Filme filme)
    {
        switch (usuario.Plano)
        {
            case PlanoEnum.Premium:
                return true;
                break;
            case PlanoEnum.Nerd when filme.Genero == GeneroEnum.Ficcao || filme.Genero == GeneroEnum.Fantasia:
                return true;
                break;
            case PlanoEnum.Kids when filme.Classificacao == ClassificacaoIndicativa.livre:
                return true;
                break;
            case PlanoEnum.Free when filme.Genero == GeneroEnum.Comedia:
                return true;
                break;
            default:
                return false;
                break;
        }
    }
}