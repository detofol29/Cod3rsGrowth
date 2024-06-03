using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.RepositoriosMock;

public class AtorRepositorioMock : IAtorRepositorio
{
    private readonly List<Ator> tabelasSingleton;

    public AtorRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstanciaAtores;
    }

    public Ator ObterPorId(int id)
    {
        return tabelasSingleton.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Ator nao encontrado");
    }

    public List<Ator> ObterTodos()
    {
        return tabelasSingleton;
    }

    public void Inserir(Ator ator)
    {
        TabelasSingleton.ObterInstanciaAtores.Add(ator);
    }

    public void Adicionar(Ator ator)
    {
        tabelasSingleton.Add(ator);
    }

    public void Remover(int id)
    {
        var ator = ObterPorId(id);
        tabelasSingleton.Remove(ator);
    }
}