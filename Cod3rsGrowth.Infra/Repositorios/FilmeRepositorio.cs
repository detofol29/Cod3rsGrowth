using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class FilmeRepositorio : IFilmeRepositorio
{
    private readonly List<Filme> tabelaFilme;
    public Filme ObterPorId(int id)
    {
        try
        {
            return tabelaFilme.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Id nao encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Filme> ObterTodos(FiltroFilme? filtroFilme)
    {
        using (var filmeContexto = new ConexaoDados())
        {
            IQueryable<Filme> query;

            query = from a in filmeContexto.TabelaFilme select a;

            if(filtroFilme == null)
            {
                return query.ToList();
            }
            else
            {
                if (filtroFilme.FiltroGenero.HasValue)
                {
                    query = query.Where(q => q.Genero == filtroFilme.FiltroGenero);
                }

                if (filtroFilme.FiltroClassificacao.HasValue)
                {
                    query = query.Where(q => q.Classificacao == filtroFilme.FiltroClassificacao);
                }

                if (filtroFilme.FiltroDisponivelNoPlano.HasValue)
                {
                    query = query.Where(q => q.DisponivelNoPlano == filtroFilme.FiltroDisponivelNoPlano);
                }

                if (filtroFilme.FiltroEmCartaz.HasValue)
                {
                    query = query.Where(q => q.EmCartaz == filtroFilme.FiltroEmCartaz);
                }

                if (filtroFilme.FiltroNotaMinima.HasValue)
                {
                    query = query.Where(q => q.Nota >= filtroFilme.FiltroNotaMinima);
                }
                return query.ToList();
            }
        }
    }

    public void Inserir(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Remover(int id)
    {
        try
        {
            var filme = ObterPorId(id);
            tabelaFilme.Remove(filme);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(int id, Filme filme)
    {
        try
        {
            var AlterarFilme = ObterPorId(id);
            AlterarFilme.Titulo = filme.Titulo;
            AlterarFilme.Nota = filme.Nota;
            AlterarFilme.DataDeLancamento = filme.DataDeLancamento;
            AlterarFilme.Genero = filme.Genero;
            AlterarFilme.EmCartaz = filme.EmCartaz;
            AlterarFilme.Duracao = filme.Duracao;
            AlterarFilme.DisponivelNoPlano = filme.DisponivelNoPlano;
            AlterarFilme.Diretor = filme.Diretor;
            AlterarFilme.Classificacao = filme.Classificacao;
            AlterarFilme.Atores = filme.Atores;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}