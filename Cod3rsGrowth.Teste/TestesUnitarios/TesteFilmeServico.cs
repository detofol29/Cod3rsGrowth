using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation.Results;
using System;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteFilmeServico : TesteBase
{
    private readonly FilmeServicos _servicos;
    public TesteFilmeServico()
    {
        _servicos = serviceProvider.GetService<FilmeServicos>() ?? throw new Exception("Serviço não encontrado!");
        _servicos.ObterTodos(null).Clear();
    }

    private Filme ObterFilmeEsperado()
    {
        return new Filme() { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre };
    }

    private List<Filme> ObterFilmes()
    {
        List<Filme> filmes = new()
        {
            new Filme{Titulo = "Vingadores"},
            new Filme{Titulo = "Homem de Ferro"},
            new Filme{Titulo = "Capitão América"},
            new Filme{Titulo = "Capitão de Ferro"}
        };

        foreach(var filme in filmes)
        {
            _servicos.CriarFilme(filme);
        }

        return filmes;
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_doze_filmes()
    {
        const int valorEsperado = 12;

        _servicos.CriarFilme(new Filme { Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.CriarFilme(new Filme { Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });

        var lista = _servicos.ObterTodos(null);

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_filme_com_id_igual_ao_esperado()
    {
        const int idFilmeEsperado = 3;

        _servicos.CriarFilme(new Filme { Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.CriarFilme(new Filme { Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });
        var filmeEsperado = ObterFilmeEsperado();

        var filmeEncontrado = _servicos.ObterPorId(idFilmeEsperado);

        Assert.NotNull(filmeEncontrado);
        Assert.Equivalent(filmeEsperado, filmeEncontrado);
    }

    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = 13;

        _servicos.CriarFilme(new Filme { Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze });
        _servicos.CriarFilme(new Filme { Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis });
        _servicos.CriarFilme(new Filme { Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze });
        _servicos.CriarFilme(new Filme { Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito });
        _servicos.CriarFilme(new Filme { Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze });

        var mensagemEsperada = "Filme nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }

    [Fact]
    public void ao_criar_filme_com_titulo_vazio_retorna_mensagem_de_erro()
    {
        const string resultadoEsperado = "O campo 'Titulo' não pode estar vazio!";
        Filme filme = new()
        {
            Titulo = "",
        };

        ValidationResult resultado = _servicos.CriarFilme(filme);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Titulo")?.ErrorMessage;

        Assert.Equal(resultadoEsperado, mensagemErro);
    }

    [Fact]
    public void ao_criar_filme_com_data_de_lancamento_superior_a_data_atual_retorna_mensagem_de_erro()
    {
        const int acrescimo = 1;
        const string resultadoEsperado = "O campo 'data de lançamento' não pode ser superior a data atual";
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

    [Fact]
    public void ao_editar_filme_retorna_o_filme_editado_com_o_mesmo_id_do_filme_substituido()
    {
        Filme filmeBase = new Filme()
        {
            Titulo = "A revolta de Zuck"
        };


        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        Filme filmeEditado = new Filme()
        {
            Titulo = "A vingança de Zuck",
            Id = idBase
        };

        _servicos.Editar(filmeEditado);
        var filmeRecuperado = _servicos.ObterPorId(idBase);

        Assert.Equivalent(filmeBase, filmeRecuperado);
        Assert.Equal(idBase, filmeRecuperado.Id);
    }

    [Fact]
    public void ao_editar_filme_retorna_filme_com_titulo_editado()
    {
        Filme filmeBase = new Filme()
        {
            Titulo = "A revolta de Zuck"
        };


        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        Filme filmeEditado = new Filme()
        {
            Titulo = "A vingança de Zuck",
            Id = idBase
        };
        _servicos.Editar(filmeEditado);
        var filmeRecuperado = _servicos.ObterPorId(idBase);
        Assert.Equal(filmeEditado.Titulo, filmeRecuperado.Titulo);
        Assert.Equivalent(filmeBase, filmeRecuperado);
    }

    [Fact]
    public void ao_editar_nota_do_filme_retorna_nota_editada_e_com_mesmo_titulo()
    {
        const int notaInicial = 4;
        const int notaFinal = 7;
        Filme filmeBase = new Filme()
        {
            Titulo = "A revolta de Zuck",
            Nota = notaInicial
        };


        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        Filme filmeEditado = new Filme()
        {
            Titulo = "A revolta de Zuck",
            Nota = notaFinal,
            Id = idBase
        };
        _servicos.Editar(filmeEditado);
        var filmeRecuperado = _servicos.ObterPorId(idBase);

        Assert.Equal(notaFinal, filmeRecuperado.Nota);
        Assert.Equal(filmeBase.Titulo, filmeRecuperado.Titulo);
        Assert.Equivalent(filmeBase, filmeRecuperado);
    }

    [Fact]
    public void ao_editar_filme_passando_filme_sem_titulo_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'Titulo' não pode estar vazio!";

        Filme filmeBase = new()
        {
            Titulo = "A revolta de Zuck"
        };

        Filme filmeEditado = new()
        {
            Titulo = ""
        };

        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(filmeEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_filme_passando_filme_com_data_de_lancamento_superior_a_atual_retorna_mensagem_de_erro()
    {
        const int acrescimo = 1;
        const string mensagemEsperada = "O campo 'data de lançamento' não pode ser superior a data atual";
        var dataOriginal = new DateTime(2020, 02, 22, 00, 00, 00);
        var dataFutura = DateTime.Now.AddDays(acrescimo);

        Filme filmeBase = new()
        {
            Titulo = "A revolta de Zuck",
            DataDeLancamento = dataOriginal
        };

        Filme filmeEditado = new()
        {
            Titulo = "A revolta de Zuck",
            DataDeLancamento = dataFutura
        };

        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(filmeEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_remover_filme_da_lista_retorna_lista_com_um_item_a_menos_ao_ObterTodos()
    {
        const int quantidadePosRemocao = 3;
        const int indiceIdParaRemocao = 3;

        var filmes = ObterFilmes();
        var idParaRemocao = filmes[indiceIdParaRemocao].Id;
        _servicos.Remover(idParaRemocao);
        var listaDeFilmesPosRemocao = _servicos.ObterTodos(null);

        Assert.Equal(quantidadePosRemocao, listaDeFilmesPosRemocao.Count());
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(100)]
    [InlineData(0)]
    public void ao_remover_filme_passando_um_id_invalido_retorna_mensagem_de_erro(int id)
    {
        var idInvalido = id;
        const string mensagemEsperada = "Filme nao encontrado";

        var filmes = ObterFilmes();

        var ex = Assert.Throws<Exception>(() => _servicos.Remover(idInvalido));
        Assert.Equal(mensagemEsperada, ex.Message);
    }
}