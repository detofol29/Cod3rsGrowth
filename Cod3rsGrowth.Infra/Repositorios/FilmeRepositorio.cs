using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class FilmeRepositorio : IFilmeRepositorio
{
    private static FilmeRepositorio _instancia;
    private readonly List<Filme> tabelaFilme;
    public Filme ObterPorId(int id)
    {
        return tabelaFilme.FirstOrDefault(a => a.Id == id);
    }

    public List<Filme> ObterTodos()
    {
        return tabelaFilme;
    }

    public void Adicionar(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Inserir(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        tabelaFilme.Remove(filme);
    }
}