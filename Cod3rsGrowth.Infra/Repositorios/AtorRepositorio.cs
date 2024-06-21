using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using System.Reflection.Metadata.Ecma335;

namespace Cod3rsGrowth.Infra.Repositorios;

public class AtorRepositorio : IAtorRepositorio
{
    ConexaoDados atorContexto = new();
    public Ator ObterPorId(int id)
    {
        return atorContexto.GetTable<Ator>().FirstOrDefault(p => p.Id == id) ?? throw new Exception("Ator não encontrado");
    }

    public List<Ator> ObterTodos(FiltroAtor? filtroAtor)
    {
        using (var AtorContexto = new ConexaoDados())
        {
            IQueryable<Ator> query = from a in AtorContexto.TabelaAtor select a;

            if (filtroAtor?.FiltroIdFilme != null)
            {
                query = from a in query
                        where a.IdFilme == filtroAtor.FiltroIdFilme
                        select a;
            }
            return query.ToList();
        }
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