using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

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

    private List<Filme> ObterFilmesCompletos()
    {
        List<Filme> filmes = new()
        {
            new Filme { Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 10},
            new Filme { Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = false, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 5 },
            new Filme { Titulo = "Star Wars", Genero = GeneroEnum.Aventura, Classificacao = ClassificacaoIndicativa.livre, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 10 },
            new Filme { Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 3 },
            new Filme { Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Terror, Classificacao = ClassificacaoIndicativa.quatorze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 8 },
            new Filme { Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 9 },
            new Filme { Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = true, Nota = 6 },
            new Filme { Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 1 },
            new Filme { Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 8 },
            new Filme { Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = false, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = true, Nota = 10 },
            new Filme { Titulo = "Pulp Fiction", Genero = GeneroEnum.Comedia, Classificacao = ClassificacaoIndicativa.dezoito, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 10 },
            new Filme { Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze, Atores = null, DataDeLancamento = new DateTime(1985, 12, 05), DisponivelNoPlano = true, Diretor = "Robert Zemeckis", Duracao = 116, EmCartaz = false, Nota = 5 },
        };

        foreach (var filme in filmes)
        {
            _servicos.CriarFilme(filme);
        }

        return filmes;
    }

    private void RemoverFilmesCompletos(List<Filme> filmes)
    {
        foreach(var filme in filmes)
        {
            _servicos.Remover(filme.Id);
        }
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_doze_filmes()
    {
        const int valorEsperado = 12;
        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();

        var lista = _servicos.ObterTodos(null);

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
     public void ao_ObterPorId_retorna_filme_com_id_igual_ao_esperado()
    {

        var filme1 = new Filme() { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre };
        var filme2 = new Filme() { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze };
        var filme3 = new Filme() { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre };

        _servicos.Inserir(filme1);
        _servicos.Inserir(filme2);
        _servicos.Inserir(filme3);

        var idFilmeEsperado = filme3.Id;

        var filmeEncontrado = _servicos.ObterPorId(idFilmeEsperado);

        Assert.Equivalent(filme3, filmeEncontrado);
    }

    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = -13;
        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();

        var mensagemEsperada = "Filme nao encontrado";
        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }

    [Fact]
    public void ao_criar_filme_com_titulo_vazio_retorna_mensagem_de_erro()
    {
        const string resultadoEsperado = "O campo 'Título' não pode estar vazio!";
        Filme filme = new()
        {
            Titulo = "",
        };

        var resultado = _servicos.CriarFilme(filme);
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
        var idBase = 1;
        Filme filmeBase = new Filme()
        {
            Titulo = "A revolta de Zuck",
            Diretor = "O Testador do futuro",
            Duracao = 120,
            Id = idBase,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
        };


        _servicos.Inserir(filmeBase);
        Filme filmeEditado = new Filme()
        {
            Titulo = "A vingança de Zuck",
            Id = idBase,
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
        };

        _servicos.Editar(filmeEditado);
        var filmeRecuperado = _servicos.ObterPorId(idBase);

        Assert.Equivalent(filmeEditado, filmeRecuperado);
        Assert.Equal(idBase, filmeRecuperado.Id);
    }

    [Fact]
    public void ao_editar_filme_retorna_filme_com_titulo_editado()
    {
        Filme filmeBase = new Filme()
        {
            Titulo = "A revolta de Zuck",
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
        };


        _servicos.Inserir(filmeBase);
        var idBase = filmeBase.Id;
        Filme filmeEditado = new Filme()
        {
            Titulo = "A vingança de Zuck",
            Id = idBase,
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
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
            Nota = notaInicial,
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
        };


        _servicos.CriarFilme(filmeBase);
        var idBase = filmeBase.Id;
        Filme filmeEditado = new Filme()
        {
            Titulo = "A revolta de Zuck",
            Nota = notaFinal,
            Id = idBase,
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
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
        const string mensagemEsperada = "O campo 'Título' não pode estar vazio!\r\n";

        Filme filmeBase = new()
        {
            Titulo = "A revolta de Zuck",
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
        };

        Filme filmeEditado = new()
        {
            Titulo = "",
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = new DateTime(2020, 02, 22, 00, 00, 00)
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
        const string mensagemEsperada = "O campo 'data de lançamento' não pode ser superior a data atual\r\n";
        var dataOriginal = new DateTime(2020, 02, 22, 00, 00, 00);
        var dataFutura = DateTime.Now.AddDays(acrescimo);

        Filme filmeBase = new()
        {
            Titulo = "A revolta de Zuck",
            Diretor = "O Testador do futuro",
            Duracao = 120,
            DataDeLancamento = dataOriginal
        };

        Filme filmeEditado = new()
        {
            Titulo = "A revolta de Zuck",
            Diretor = "O Testador do futuro",
            Duracao = 120,
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
        const int quantidadePosRemocao = 11;
        const int indiceIdParaRemocao = 3;

        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        var filmes = ObterFilmesCompletos();

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

    [Theory]
    [InlineData(GeneroEnum.Ficcao, 2)]
    [InlineData(GeneroEnum.Acao, 2)]
    [InlineData(GeneroEnum.Romance, 1)]
    [InlineData(GeneroEnum.Comedia, 1)]
    [InlineData(GeneroEnum.Drama, 2)]
    [InlineData(GeneroEnum.Aventura, 1)]
    [InlineData(GeneroEnum.Terror, 1)]
    [InlineData(GeneroEnum.Fantasia, 2)]
    public void ao_ObterTodos_com_filtro_de_genero_retorna_filme_com_genero_esperado(GeneroEnum genero, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        GeneroEnum generoEsperado = genero;

        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();
        var filtro = new FiltroFilme()
        {
            FiltroGenero = generoEsperado
        };
        var listaDeFilmesObtida = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, listaDeFilmesObtida.Count());
    }

    [Theory]
    [InlineData(ClassificacaoIndicativa.livre, 2)]
    [InlineData(ClassificacaoIndicativa.doze, 1)]
    [InlineData(ClassificacaoIndicativa.quatorze, 5)]
    [InlineData(ClassificacaoIndicativa.dezoito, 2)]
    public void ao_ObterTodos_com_filtro_de_classificacao_retorna_filme_com_classificacao_esperada(ClassificacaoIndicativa classificacao, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        ClassificacaoIndicativa classificacaoEsperada = classificacao;

        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();
        
        var filtro = new FiltroFilme()
        {
            FiltroClassificacao = classificacaoEsperada
        };
        var listaDeFilmesObtida = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, listaDeFilmesObtida.Count());
    }
    [Theory]
    [InlineData(true, 10)]
    [InlineData(false, 2)]
    public void ao_ObterTodos_com_filtro_de_disponibilidade_retorna_filme_com_disponibilidade_esperada(bool disponivelNoPlano, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        bool disponibilidadeEsperada = disponivelNoPlano;
        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();
        
        var filtro = new FiltroFilme()
        {
            FiltroDisponivelNoPlano = disponibilidadeEsperada
        };
        var listaDeFilmesObtida = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, listaDeFilmesObtida.Count());
    }

    [Theory]
    [InlineData(true, 2)]
    [InlineData(false, 10)]
    public void ao_ObterTodos_com_filtro_de_EmCartaz_retorna_filme_com_EmCartaz_esperado(bool emCartaz, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        bool emCartazEsperado = emCartaz;
        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();

        var filtro = new FiltroFilme()
        {
            FiltroEmCartaz = emCartaz
        };
        var listaDeFilmesObtida = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, listaDeFilmesObtida.Count());
    }

    [Theory]
    [InlineData(5, 10)]
    [InlineData(7, 7)]
    [InlineData(10, 4)]
    public void ao_obterTodos_com_filtro_de_nota_minima_retorna_filmes_esperados(int notaMinima, int quantidade)
    {
        var quantidadeEsperada = quantidade;
        var notaMinimaEsperada = notaMinima;
        RemoverFilmesCompletos(_servicos.ObterTodos(null));
        ObterFilmesCompletos();
        
        var filtro = new FiltroFilme()
        {
            FiltroNotaMinima = notaMinimaEsperada
        };
        var listaDeFilmesObtida = _servicos.ObterTodos(filtro);

        Assert.Equal(quantidadeEsperada, listaDeFilmesObtida.Count());
    }
}