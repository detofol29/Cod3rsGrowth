using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using System.Reflection.Metadata.Ecma335;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation.Results;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteAtorServico : TesteBase
{
    private readonly AtorServicos _servicos;
    public TesteAtorServico()
    {
        _servicos = serviceProvider.GetService<AtorServicos>() ?? throw new Exception("Servico não encontrado");
        _servicos.ObterTodos(null).Clear();
    }

    private Ator ObterAtorEsperado()
    {
        return new Ator() { Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } };
    }

    private List<Ator> ObterAtores()
    {
        List<Ator> atores = new()
        {
            new Ator{Nome = "Gabriel"},
            new Ator{Nome = "Rubens"},
            new Ator{Nome = "Marcos"},
            new Ator{Nome = "André"}
        };

        foreach(var ator in atores)
        {
            _servicos.CriarAtor(ator);
        }

        return atores;
    } 

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_trinta_e_oito_atores()
    {
        const int valorEsperado = 38;

        _servicos.CriarAtor(new() { Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards" } });
        _servicos.CriarAtor(new() { Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ian McKellen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Viggo Mortensen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Orlando Bloom", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Sean Astin", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Elijah Wood", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ian McKellen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Viggo Mortensen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Orlando Bloom", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Sean Astin", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Elijah Wood", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ian McKellen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Viggo Mortensen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Orlando Bloom", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Sean Astin", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Keanu Reeves", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Laurence Fishburne", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Carrie-Anne Moss", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Russell Crowe", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Joaquin Phoenix", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Connie Nielsen", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Marlon Brando", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Al Pacino", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "James Caan", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Tom Hanks", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Robin Wright", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Gary Sinise", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "John Travolta", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Uma Thurman", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Samuel L. Jackson", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Christian Bale", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Heath Ledger", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Aaron Eckhart", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });

        var lista = _servicos.ObterTodos(null);

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_ator_com_id_igual_ao_esperado()
    {
        const int idAtorEsperado = 3;

        _servicos.CriarAtor(new() { Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards" } });
        _servicos.CriarAtor(new() { Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });

        var atorEsperado = ObterAtorEsperado();
        var atorEncontrado = _servicos.ObterPorId(idAtorEsperado);

        Assert.Equivalent(atorEsperado, atorEncontrado);
    }
    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = -1;

        _servicos.CriarAtor(new() { Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.CriarAtor(new() { Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards" } });
        _servicos.CriarAtor(new() { Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        var mensagemEsperada = "Ator nao encontrado";

        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }

    [Fact]
    public void ao_criar_ator_sem_nome_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo de 'Nome' não pode estar vazio!";

        Ator ator = new()
        {
            Nome = "",
        };

        ValidationResult resultado = _servicos.CriarAtor(ator);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nome")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemErro);
    }
    [Fact]
    public void ao_criar_ator_com_nome_contendo_numero_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'Nome' não deve conter números!";
        const string nomeComNumero = "Roberto7";

        Ator ator = new()
        {
            Nome = nomeComNumero,
        };

        var resultado = _servicos.CriarAtor(ator);
        var mensagemDeErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nome")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemDeErro);
    }

    [Fact]
    public void ao_editar_ator_retorna_ator_com_nome_editado()
    {
        Ator atorBase = new()
        {
            Nome = "Criss Byuither"
        };

        _servicos.CriarAtor(atorBase);
        var idBase = atorBase.Id;
        Ator atorEditado = new()
        {
            Nome = "Criss Byuither Silva",
            Id = idBase
        };

        _servicos.Editar(atorEditado);
        var atorEncontrado = _servicos.ObterPorId(idBase);

        Assert.Equal(atorEditado.Nome, atorEncontrado.Nome);
        Assert.Equivalent(atorBase, atorEncontrado);
    }

    [Fact]
    public void ao_editar_ator_com_nome_vazio_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo de 'Nome' não pode estar vazio!";

        Ator atorBase = new()
        {
            Nome = "Criss Byuither"
        };

        Ator atorEditado = new()
        {
            Nome = ""
        };

        _servicos.CriarAtor(atorBase);
        var idBase = atorBase.Id;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(atorEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_editar_ator_com_nome_contendo_numeros_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "O campo 'Nome' não deve conter números!";

        Ator atorBase = new()
        {
            Nome = "Criss Byuither"
        };

        Ator atorEditado = new()
        {
            Nome = "Criss Byuither Silva45"
        };

        _servicos.CriarAtor(atorBase);
        var idBase = atorBase.Id;
        var ex = Assert.Throws<Exception>(() => _servicos.Editar(atorEditado));
        Assert.Equal(mensagemEsperada, ex.Message);
    }

    [Fact]
    public void ao_remover_ator_da_lista_retorna_lista_com_um_item_a_menos_ao_ObterTodos()
    {
        const int quantidadePosRemocao = 3;
        const int indiceIdParaRemocao = 3;

        var atores = ObterAtores();
        var idParaRemocao = atores[indiceIdParaRemocao].Id;
        _servicos.Remover(idParaRemocao);
        var listaDeAtoresPosRemocao = _servicos.ObterTodos(null);

        Assert.Equal(quantidadePosRemocao, listaDeAtoresPosRemocao.Count());
    }

    [Theory]
    [InlineData(-12)]
    [InlineData(100)]
    [InlineData(0)]
    public void ao_remover_ator_passando_um_id_invalido_retorna_mensagem_de_erro(int id)
    {
        var idInvalido = id;
        const string mensagemEsperada = "Ator nao encontrado";

        ObterAtores();

        var ex = Assert.Throws<Exception>(() => _servicos.Remover(idInvalido));
        Assert.Equal(mensagemEsperada, ex.Message);
    }
}