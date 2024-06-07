using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Validations;
using FluentValidation.Results;
using System;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteFilmeServico : TesteBase
{
    private readonly FilmeServicos _servicos;
    private readonly FilmeValidation _validator;
    public TesteFilmeServico()
    {
        _servicos = serviceProvider.GetService<FilmeServicos>() ?? throw new Exception("servico nao encontrado");
        _validator = new FilmeValidation();
    }

    private Filme ObterFilmeEsperado()
    {
        return new Filme() { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre };
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_doze_filmes()
    {
        const int valorEsperado = 12;

        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze});
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis});
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis});
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito});
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze});
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito});
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze});

        var lista = _servicos.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_filme_com_id_igual_a_3()
    {
        const int idFilme = 3;

        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });
        var filmeEsperado = ObterFilmeEsperado();

        var filmeEncontrado = _servicos.ObterPorId(idFilme);

        Assert.NotNull(filmeEncontrado);
        Assert.Equivalent(filmeEsperado, filmeEncontrado);
    }

    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = 13;

        _servicos.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });

        var mensagemEsperada = "Filme nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }

    [Fact]
    public void ao_criar_filme_com_titulo_vazio_retorna_mensagem_de_erro()
    {
        const int id = 20;
        const string resultadoEsperado = "Campo de titulo obrigatorio";
        Filme filme = new()
        {
            Titulo = "",
            Id = id
        };

        ValidationResult resultado = _servicos.CriarFilme(filme);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Titulo")?.ErrorMessage;

        Assert.Equal(resultadoEsperado, mensagemErro);
    }

    [Fact]
    public void ao_criar_filme_com_id_nulo_retorna_mensagem_de_erro()
    {
        const string resultadoEsperado = "Id não cadastrado";
        Filme filme = new()
        {
            Titulo = "Tucanos Assassinos",
        };
        ValidationResult resultado = _servicos.CriarFilme(filme);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Id")?.ErrorMessage;
        Assert.Equal(resultadoEsperado, mensagemErro);
    }

    [Fact]
    public void ao_criar_filme_com_id_negativo_retorna_mensagem_de_erro()
    {
        const string resultadoEsperado = "Id nao pode ser negativo";
        const int idNegativo = -12;
        Filme filme = new()
        {
            Titulo = "Tucanos Assassinos",
            Id = idNegativo
        };
        ValidationResult resultado = _servicos.CriarFilme(filme);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Id")?.ErrorMessage;
        Assert.Equal(resultadoEsperado, mensagemErro);
    }

    [Fact]
    public void ao_criar_filme_com_data_de_lancamento_superior_a_data_atual_retorna_mensagem_de_erro()
    {
        const int acrescimo = 1;
        const string resultadoEsperado = "A data de lancamento nao pode ser superior a data atual";
        DateTime dataFutura = DateTime.Now.AddDays(acrescimo);

        Filme filme = new()
        {
            Titulo = "A revolta dos tomates",
            DataDeLancamento = dataFutura
        };

        ValidationResult resultado = _servicos.CriarFilme(filme);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "DataDeLancamento")?.ErrorMessage;
        Assert.Equal(resultadoEsperado, mensagemErro);
    }
}