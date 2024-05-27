using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;


namespace Cod3rsGrowth.Teste;

public class TesteRepositorioFilme : TesteBase
{
    private readonly IFilmeRepositorio filmeRepositorio;
    public TesteRepositorioFilme()
    {
        filmeRepositorio = serviceProvider.GetService<IFilmeRepositorio>() ?? throw new Exception("Repositorio nao encontrado");
    }


    [Theory]
    [InlineData(0)][InlineData(1)][InlineData(2)][InlineData(3)][InlineData(4)][InlineData(5)]
    [InlineData(6)][InlineData(7)][InlineData(8)][InlineData(9)][InlineData(10)][InlineData(11)]
    public void ObterTodosRetornaListaDeTodosOsFilmesDoRepositorioQuandoListaNaoNula(int indice)
    {
        //Arrange
        List<Filme> listaEsperada = TabelasSingleton.ObterInstacniaFilmes;

        string titulo = listaEsperada[indice].Titulo;
        int id = listaEsperada[indice].Id;
        GeneroEnum genero = listaEsperada[indice].Genero;
        ClassificacaoIndicativa classificacao = listaEsperada[indice].Classificacao;

        //Act
        var lista = filmeRepositorio.ObterTodos();

        //Assart
        Assert.NotNull(lista);
        Assert.Equal(lista[indice].Titulo, titulo);
        Assert.Equal(lista[indice].Id, id);
        Assert.Equal(lista[indice].Genero, genero);
        Assert.Equal(lista[indice].Classificacao, classificacao);
    }
}
