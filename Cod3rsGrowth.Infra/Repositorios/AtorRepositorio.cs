using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class AtorRepositorio : IAtorRepositorio
{
    private readonly List<Ator> tabelaAtor;
    public Ator ObterPorId(int id)
    {
        try
        {
            return tabelaAtor.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Id nao encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Ator> ObterTodos()
    {
        return tabelaAtor;
    }

    public void Inserir(Ator ator)
    {
        tabelaAtor.Add(ator);
    }

    public void Remover(int id)
    {
        try
        {
            var ator = ObterPorId(id);
            tabelaAtor.Remove(ator);
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}