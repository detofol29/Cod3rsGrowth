using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Dominio.Filtros;

namespace Cod3rsGrowth.Teste.RepositoriosMock;

public class FilmeRepositorioMock :IFilmeRepositorio
{
    private readonly List<Filme> tabelasSingleton;
    public FilmeRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstanciaFilmes;
    }
    public void Inserir(Filme filme)
    {
        tabelasSingleton.Add(filme);
    }

    public Filme ObterPorId(int id)
    {
        try
        {
            return tabelasSingleton.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Filme nao encontrado");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Filme> ObterTodos(FiltroFilme? filtroFilme)
    {
        IQueryable<Filme> query = tabelasSingleton.AsQueryable();

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
                    where a.Nota >= filtroFilme.FiltroNotaMinima
                    select a;
        }
        return query.ToList();
    }

    public void Remover(int id)
    {
        try
        {
            var filme = ObterPorId(id);
            tabelasSingleton.Remove(filme);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(Filme filme)
    {
        try
        {
            var AlterarFilme = ObterPorId(filme.Id);
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
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}