using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Filtros;

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
        try
        {
            return tabelasSingleton.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Ator nao encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Ator> ObterTodos(FiltroAtor? ator)
    {
        return tabelasSingleton;
    }
    
    public void Inserir(Ator ator)
    {
        tabelasSingleton.Add(ator);
    }

    public void Remover(int id)
    {
        try
        {
            var ator = ObterPorId(id);
            tabelasSingleton.Remove(ator);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(int id, Ator ator)
    {
        try
        {
            var alterarAtor = ObterPorId(id);
            alterarAtor.Nome = ator.Nome;
            alterarAtor.Premios = ator.Premios;
            alterarAtor.IdFilme = ator.IdFilme;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}