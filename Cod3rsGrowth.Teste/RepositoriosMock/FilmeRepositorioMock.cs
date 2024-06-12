using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
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

    public void Ordenar()
    {
        tabelasSingleton.OrderBy(n => n.Id);
    }

    public void Editar(int id, Filme filme)
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

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        tabelasSingleton.Remove(filme);
    }
}