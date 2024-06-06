using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Servicos.Servicos;

public class AtorServicos : IAtorRepositorio
{
    private readonly IAtorRepositorio _atorRepositorio;
    public AtorServicos(IAtorRepositorio atorRepositorio)
    {
        _atorRepositorio = atorRepositorio;
    }
    public List<string> ObterPremiosDoAtor(Ator ator)
    {
        return ator.Premios;
    }

    public List<Ator> ObterTodos()
    {
        return _atorRepositorio.ObterTodos();
    }

    public Ator ObterPorId(int id)
    {
        return _atorRepositorio.ObterPorId(id);
    }

    public void Inserir(Ator ator)
    {
        _atorRepositorio.Inserir(ator);
    }
}