using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using System.Reflection.Metadata.Ecma335;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste;

public class FilmeRepositorioMock : IRepositorio<Filme>
{
    private readonly List<Filme> tabelasSingleton;

    public FilmeRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstanciaFilmes;
    }

    public Filme ObterPorId(int id)
    {
        return tabelasSingleton.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Filme nao encontrado");
    }

    public List<Filme> ObterTodos() 
    {
        return tabelasSingleton;
    }

    public void Adicionar(Filme filme)
    {
        tabelasSingleton.Add(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        tabelasSingleton.Remove(filme);
    }
}