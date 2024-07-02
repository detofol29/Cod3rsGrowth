using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Cod3rsGrowth.Infra.Repositorios;

public class FilmeRepositorio : IFilmeRepositorio
{
    private readonly ConexaoDados filmeContexto;

    public FilmeRepositorio(ConexaoDados _conexao)
    {
        filmeContexto = _conexao;
    }
    public Filme ObterPorId(int id)
    {
        return filmeContexto.GetTable<Filme>().FirstOrDefault(p => p.Id == id) ?? throw new Exception("Filme não encontrado");
    }

    public List<Filme> ObterTodos(FiltroFilme? filtroFilme)
    {
    
        IQueryable<Filme> query = from a in filmeContexto.TabelaFilme select a;

        if (filtroFilme?.FiltroGenero != null)
        {
            query = from a in query
                    where a.Genero == filtroFilme.FiltroGenero
                    select a;
        }

        if (filtroFilme?.FiltroClassificacao != null)
        {
            query = from a in query
                    where a.Classificacao == filtroFilme.FiltroClassificacao
                    select a;
        }

        if (filtroFilme?.FiltroDisponivelNoPlano != null)
        {
            query = from a in query
                    where a.DisponivelNoPlano == filtroFilme.FiltroDisponivelNoPlano
                    select a;
        }

        if (filtroFilme?.FiltroEmCartaz != null)
        {
            query = from a in query
                    where a.EmCartaz == filtroFilme.FiltroEmCartaz
                    select a;
        }

        if (filtroFilme?.FiltroNotaMinima != null)
        {
            query = from a in query
                    where a.Nota == filtroFilme.FiltroNotaMinima
                    select a;
        }
        return query.ToList<Filme>();
    }

    public void Inserir(Filme filme)
    {
        filmeContexto.Insert(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        filmeContexto.Delete(filme);
    }

    public void Editar(Filme filme)
    {
        filmeContexto.Update(filme);
    }
}