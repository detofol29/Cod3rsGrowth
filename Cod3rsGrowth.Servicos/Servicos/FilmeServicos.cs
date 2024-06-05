using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Servicos.Servicos;

public class FilmeServicos : IFilmeRepositorio
{
    private readonly IFilmeRepositorio _filmeRepositorio;
    public FilmeServicos(IFilmeRepositorio filmeRepositorio)
    {
        _filmeRepositorio = filmeRepositorio;
    }

    public List<Filme> ObterTodos()
    {
        return _filmeRepositorio.ObterTodos();
    }

    public Filme ObterPorId(int id)
    {
        return _filmeRepositorio.ObterPorId(id);
    }

    public void Inserir(Filme filme)
    {
        _filmeRepositorio.Inserir(filme);
    }

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