using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.RepositoriosMock;

public class FilmeRepositorioMock : IFilmeRepositorio
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

    public List<Filme> ObterTodos()
    {
        return tabelasSingleton;
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
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}