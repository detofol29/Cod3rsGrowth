using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class FilmeRepositorio : IFilmeRepositorio
{
    private static FilmeRepositorio _instancia;
    private readonly List<Filme> tabelaFilme;
    public Filme ObterPorId(int id)
    {
        return tabelaFilme.FirstOrDefault(a => a.Id == id) ?? throw new Exception("Id nao encontrado");
    }

     public List<Filme> ObterTodos()
    {
        return tabelaFilme;
    }

    public void Adicionar(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Inserir(Filme filme)
    {
        tabelaFilme.Add(filme);
    }

    public void Remover(int id)
    {
        var filme = ObterPorId(id);
        tabelaFilme.Remove(filme);
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
}