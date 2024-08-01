using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class AtorRepositorio : IAtorRepositorio
{
    private readonly ConexaoDados atorContexto;
    public AtorRepositorio(ConexaoDados _conexao)
    {
        atorContexto = _conexao;
    }
    
    public Ator ObterPorId(int id)
    {
        return atorContexto.GetTable<Ator>().FirstOrDefault(p => p.Id == id) ?? throw new Exception("Ator não encontrado");
    }

    public List<Ator> ObterTodos(FiltroAtor? filtroAtor)
    {
        IQueryable<Ator> query = from a in atorContexto.TabelaAtor select a;

        if (filtroAtor?.FiltroIdFilme != null)
        {
            query = from a in query
                    where a.IdFilme == filtroAtor.FiltroIdFilme
                    select a;
        }
        return query.ToList();
    }

    public void Inserir(Ator ator)
    {
        atorContexto.Insert(ator);
    }

    public void Remover(int id)
    {
        var ator = ObterPorId(id);
        atorContexto.Delete(ator);
    }

    public void Editar(Ator ator)
    {
        atorContexto.Update(ator);
    }
}