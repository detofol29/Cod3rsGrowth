using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste;

public class TesteRepositorios : TesteBase
{
    private readonly IRepositorio<Filme> filmeRepositorio;
    private readonly IRepositorio<Ator> atorRepositorio;
    private readonly IRepositorio<Usuario> usuarioRepositorio;
    public TesteRepositorios()
    {
        filmeRepositorio = serviceProvider.GetService<IRepositorio<Filme>>() ?? throw new Exception("Repositorio nao encontrado");
        atorRepositorio = serviceProvider.GetService<IRepositorio<Ator>>() ?? throw new Exception("Repositorio nao encontrado");
        usuarioRepositorio = serviceProvider.GetService<IRepositorio<Usuario>>() ?? throw new Exception("Repositorio nao encontrado");
    }

    [Theory]
    [InlineData(0)][InlineData(1)][InlineData(2)][InlineData(3)][InlineData(4)][InlineData(5)]
    [InlineData(6)][InlineData(7)][InlineData(8)][InlineData(9)][InlineData(10)][InlineData(11)]
    public void ObterTodosRetornaListaDeTodosOsFilmesDoRepositorioQuandoListaNaoNula(int indice)
    {
        List<Filme> listaEsperada = TabelasSingleton.ObterInstanciaFilmes;
        string titulo = listaEsperada[indice].Titulo;
        int id = listaEsperada[indice].Id;
        GeneroEnum genero = listaEsperada[indice].Genero;
        ClassificacaoIndicativa classificacao = listaEsperada[indice].Classificacao;

        var lista = filmeRepositorio.ObterTodos();

        Assert.NotNull(lista);
        Assert.Equal(lista[indice].Titulo, titulo);
        Assert.Equal(lista[indice].Id, id);
        Assert.Equal(lista[indice].Genero, genero);
        Assert.Equal(lista[indice].Classificacao, classificacao);
        Assert.Equal(listaEsperada.Count(), lista.Count());
    }

    public static IEnumerable<object[]> Indices()
    {
        for (int i = 0; i <= 37; i++)
        {
            yield return new object[] { i };
        }
    }

    [Theory]
    [MemberData(nameof(Indices))]
    public void ObterTodosRetornaListaDeTodosOsAtoresDoRepositorioQuandoListaNaoNula(int indice)
    {
        List<Ator> listaEsperada = TabelasSingleton.ObterInstanciaAtores;
        string nome = listaEsperada[indice].Nome;
        int id = listaEsperada[indice].Id;

        var lista = atorRepositorio.ObterTodos();

        Assert.NotNull(lista);
        Assert.Equal(nome, lista[indice].Nome);
        Assert.Equal(id, lista[indice].Id);
    }

    [Theory]
    [InlineData(0)][InlineData(1)][InlineData(2)][InlineData(3)]
    public void ObterTodosRetornaListaDeTodosOsUsuariosDoRepositorioQuandoListaNaoNula(int indice)
    {
        var listaEsperada = TabelasSingleton.ObterInstanciaUsuarios;
        string nome = listaEsperada[indice].Nome;
        int id = listaEsperada[indice].IdUsuario;
        string senha = listaEsperada[indice].Senha;
        string nick = listaEsperada[indice].NickName;

        var lista = usuarioRepositorio.ObterTodos();

        Assert.NotNull(lista);
        Assert.Equal(nome, lista[indice].Nome);
        Assert.Equal(id, lista[indice].IdUsuario);
        Assert.Equal(senha, lista[indice].Senha);
        Assert.Equal(nick, lista[indice].NickName);
    }
}