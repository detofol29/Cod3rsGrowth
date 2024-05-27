using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Dominio.Modelos;
using NuGet.Frameworks;
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
        List<Filme> listaEsperada = new List<Filme>()
        {
            new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre },
            new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze },
            new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre },
            new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze },
            new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze },
            new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze },
            new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis},
            new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis},
            new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito },
            new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze },
            new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito},
            new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze }
        };

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
