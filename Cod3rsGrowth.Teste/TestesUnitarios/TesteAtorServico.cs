using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using System.Reflection.Metadata.Ecma335;
using Cod3rsGrowth.Dominio.Validacoes;
using FluentValidation.Results;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteAtorServico : TesteBase
{
    private readonly AtorServicos _servicos;
    public TesteAtorServico()
    {
        _servicos = serviceProvider.GetService<AtorServicos>() ?? throw new Exception("Servico não encontrado");
    }

    private Ator ObterAtorEsperado()
    {
        return new Ator() { Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } };
    }

    [Fact]
    public void ao_ObterTodos_retorna_lista_com_trinta_e_oito_atores()
    {
        const int valorEsperado = 38;

        _servicos.Inserir(new() {Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 2, Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" }});
        _servicos.Inserir(new() {Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 4, Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards"}});
        _servicos.Inserir(new() {Id = 6, Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 7, Nome = "Ian McKellen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 8, Nome = "Viggo Mortensen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 9, Nome = "Orlando Bloom", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 10, Nome = "Sean Astin", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 11, Nome = "Elijah Wood", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 12, Nome = "Ian McKellen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 13, Nome = "Viggo Mortensen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 14, Nome = "Orlando Bloom", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 15, Nome = "Sean Astin", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 16, Nome = "Elijah Wood", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 17, Nome = "Ian McKellen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 18, Nome = "Viggo Mortensen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 19, Nome = "Orlando Bloom", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 20, Nome = "Sean Astin", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 21, Nome = "Keanu Reeves", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 22, Nome = "Laurence Fishburne", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 23, Nome = "Carrie-Anne Moss", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 24, Nome = "Russell Crowe", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 25, Nome = "Joaquin Phoenix", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 26, Nome = "Connie Nielsen", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 27, Nome = "Marlon Brando", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 28, Nome = "Al Pacino", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 29, Nome = "James Caan", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 30, Nome = "Tom Hanks", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 31, Nome = "Robin Wright", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 32, Nome = "Gary Sinise", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 33, Nome = "John Travolta", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 34, Nome = "Uma Thurman", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 35, Nome = "Samuel L. Jackson", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 36, Nome = "Christian Bale", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 37, Nome = "Heath Ledger", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        _servicos.Inserir(new() {Id = 38, Nome = "Aaron Eckhart", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});

        var lista = _servicos.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(valorEsperado, lista.Count());
    }

    [Fact]
    public void ao_ObterPorId_retorna_ator_com_id_igual_a_3()
    {
        const int idAtor = 3;

        _servicos.Inserir(new() { Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 2, Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 4, Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards" } });
        _servicos.Inserir(new() { Id = 6, Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });

        var atorEsperado = ObterAtorEsperado();
        var atorEncontrado = _servicos.ObterPorId(idAtor);

        Assert.Equivalent(atorEsperado, atorEncontrado);
    }
    [Fact]
    public void ao_ObterPorId_retorna_mensagem_de_erro_quando_id_nao_encontrado()
    {
        const int idNaoExistente = -1;

        _servicos.Inserir(new() { Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 2, Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 4, Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        _servicos.Inserir(new() { Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards" } });
        _servicos.Inserir(new() { Id = 6, Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards" } });
        var mensagemEsperada = "Ator nao encontrado";

        var excecao = Assert.Throws<Exception>(() => _servicos.ObterPorId(idNaoExistente));

        Assert.Equal(mensagemEsperada, excecao.Message); 
    }

    [Fact]
    public void ao_criar_ator_sem_nome_retorna_mensagem_de_erro()
    {
        const int id = 3;
        const string mensagemEsperada = "O campo de 'Nome' não pode estar vazio!";

        Ator ator = new()
        {
            Nome = "",
            Id = id
        };

        ValidationResult resultado = _servicos.CriarAtor(ator);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Nome")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemErro);
    }

    //[Fact]
    public void ao_criar_ator_sem_id_retorna_mensagem_de_erro()
    {
        const string mensagemEsperada = "Id nao pode ser nulo";

        Ator ator = new()
        {
            Nome = "Fernandin",
        };

        ValidationResult resultado = _servicos.CriarAtor(ator);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Id")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemErro);
    }

    [Fact]
    public void ao_criar_ator_com_id_negativo_retorna_mensagem_de_erro()
    {
        const int idNegativo = -1;
        const string mensagemEsperada = "O campo 'Id' precisa conter um número positivo!";

        Ator ator = new()
        {
            Nome = "Fernandin",
            Id = idNegativo
        };

        ValidationResult resultado = _servicos.CriarAtor(ator);
        var mensagemErro = resultado.Errors.FirstOrDefault(e => e.PropertyName == "Id")?.ErrorMessage;
        Assert.Equal(mensagemEsperada, mensagemErro);
    }
}