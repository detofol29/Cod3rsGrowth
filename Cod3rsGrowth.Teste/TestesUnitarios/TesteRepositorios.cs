using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.TestesUnitarios;

public class TesteRepositorios : TesteBase
{
    private readonly IFilmeRepositorio filmeRepositorio;
    private readonly IAtorRepositorio atorRepositorio;
    private readonly IUsuarioRepositorio usuarioRepositorio;
    public TesteRepositorios()
    {
        filmeRepositorio = serviceProvider.GetService<IFilmeRepositorio>() ?? throw new Exception("Repositorio nao encontrado");
        atorRepositorio = serviceProvider.GetService<IAtorRepositorio>() ?? throw new Exception("Repositorio nao encontrado");
        usuarioRepositorio = serviceProvider.GetService<IUsuarioRepositorio>() ?? throw new Exception("Repositorio nao encontrado");
    }

    [Fact]
    public void obter_todos_retorna_lista_de_todos_os_filmes_do_repositorio_quando_lista_nao_nula()
    {
        filmeRepositorio.Inserir(new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        filmeRepositorio.Inserir(new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Classificacao = ClassificacaoIndicativa.doze});
        filmeRepositorio.Inserir(new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.livre});
        filmeRepositorio.Inserir(new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        filmeRepositorio.Inserir(new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        filmeRepositorio.Inserir(new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Classificacao = ClassificacaoIndicativa.quatorze});
        filmeRepositorio.Inserir(new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Classificacao = ClassificacaoIndicativa.dezesseis});
        filmeRepositorio.Inserir(new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezesseis});
        filmeRepositorio.Inserir(new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.dezoito});
        filmeRepositorio.Inserir(new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Classificacao = ClassificacaoIndicativa.quatorze});
        filmeRepositorio.Inserir(new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.dezoito});
        filmeRepositorio.Inserir(new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Classificacao = ClassificacaoIndicativa.quatorze});
        var listaEsperada = TabelasSingleton.ObterInstanciaFilmes;
        var titulo = listaEsperada[0].Titulo;
        var id = listaEsperada[0].Id;
        var genero = listaEsperada[0].Genero;
        var classificacao = listaEsperada[0].Classificacao;

        var lista = filmeRepositorio.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(lista[0].Titulo, titulo);
        Assert.Equal(lista[0].Id, id);
        Assert.Equal(lista[0].Genero, genero);
        Assert.Equal(lista[0].Classificacao, classificacao);
        Assert.Equal(listaEsperada.Count(), lista.Count());
    }
    [Fact]
    public void obter_todos_retorna_lista_de_todos_os_atores_do_repositorio_quando_lista_nao_nula()
    {
        atorRepositorio.Inserir(new() {Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 2, Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards" }});
        atorRepositorio.Inserir(new() {Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 4, Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string> { "Oscar Melhor Ator(2016)", "Golden Globe Awards"}});
        atorRepositorio.Inserir(new() {Id = 6, Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 7, Nome = "Ian McKellen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 8, Nome = "Viggo Mortensen", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 9, Nome = "Orlando Bloom", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 10, Nome = "Sean Astin", IdFilme = 4, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 11, Nome = "Elijah Wood", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 12, Nome = "Ian McKellen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 13, Nome = "Viggo Mortensen", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 14, Nome = "Orlando Bloom", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 15, Nome = "Sean Astin", IdFilme = 5, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 16, Nome = "Elijah Wood", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 17, Nome = "Ian McKellen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 18, Nome = "Viggo Mortensen", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 19, Nome = "Orlando Bloom", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 20, Nome = "Sean Astin", IdFilme = 6, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 21, Nome = "Keanu Reeves", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 22, Nome = "Laurence Fishburne", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 23, Nome = "Carrie-Anne Moss", IdFilme = 7, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 24, Nome = "Russell Crowe", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 25, Nome = "Joaquin Phoenix", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 26, Nome = "Connie Nielsen", IdFilme = 8, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 27, Nome = "Marlon Brando", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 28, Nome = "Al Pacino", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 29, Nome = "James Caan", IdFilme = 9, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 30, Nome = "Tom Hanks", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 31, Nome = "Robin Wright", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 32, Nome = "Gary Sinise", IdFilme = 10, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 33, Nome = "John Travolta", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 34, Nome = "Uma Thurman", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 35, Nome = "Samuel L. Jackson", IdFilme = 11, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 36, Nome = "Christian Bale", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 37, Nome = "Heath Ledger", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        atorRepositorio.Inserir(new() {Id = 38, Nome = "Aaron Eckhart", IdFilme = 12, Premios = new List<string> { "SAG Awards", "Black Reel Awards"}});
        var listaEsperada = TabelasSingleton.ObterInstanciaAtores;
        var nome = listaEsperada[0].Nome;
        var id = listaEsperada[0].Id;

        var lista = atorRepositorio.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(nome, lista[0].Nome);
        Assert.Equal(id, lista[0].Id);
    }

    [Fact]
    public void obter_todos_retorna_lista_de_todos_os_usuarios_do_repositorio_quando_lista_nao_nula()
    {
        usuarioRepositorio.Inserir(new() {Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29"});
        usuarioRepositorio.Inserir(new() {Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo"});
        usuarioRepositorio.Inserir(new() {Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens"});
        usuarioRepositorio.Inserir(new() {Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau"});
        var listaEsperada = TabelasSingleton.ObterInstanciaUsuarios;
        var nome = listaEsperada[0].Nome;
        var id = listaEsperada[0].IdUsuario;
        var senha = listaEsperada[0].Senha;
        var nick = listaEsperada[0].NickName;

        var lista = usuarioRepositorio.ObterTodos();

        Assert.NotEmpty(lista);
        Assert.Equal(nome, lista[0].Nome);
        Assert.Equal(id, lista[0].IdUsuario);
        Assert.Equal(senha, lista[0].Senha);
        Assert.Equal(nick, lista[0].NickName);
    }
}