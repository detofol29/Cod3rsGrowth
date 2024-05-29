using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelasSingleton
{
    private static readonly Lazy<List<Filme>> instanciaFilme = new(() => new List<Filme>()
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
    });
    private static readonly Lazy<List<Ator>> instanciaAtor = new(() => new List<Ator>()
    {
        new(){Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"} },
        new(){Id = 2, Nome = "Ewan McGregor", IdFilme = 3, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 3, Nome = "Natalie Portman", IdFilme = 3, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 4, Nome = "Michael J. Fox", IdFilme = 1, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2, Premios = new List<string>{ "Oscar Melhor Ator(2016)", "Golden Globe Awards"}},
        new(){Id = 6, Nome = "Elijah Wood", IdFilme = 4, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 7, Nome = "Ian McKellen", IdFilme = 4, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 8, Nome = "Viggo Mortensen", IdFilme = 4, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 9, Nome = "Orlando Bloom", IdFilme = 4, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 10, Nome = "Sean Astin", IdFilme = 4, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 11, Nome = "Elijah Wood", IdFilme = 5, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 12, Nome = "Ian McKellen", IdFilme = 5, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 13, Nome = "Viggo Mortensen", IdFilme = 5, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 14, Nome = "Orlando Bloom", IdFilme = 5, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 15, Nome = "Sean Astin", IdFilme = 5, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 16, Nome = "Elijah Wood", IdFilme = 6, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 17, Nome = "Ian McKellen", IdFilme = 6, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 18, Nome = "Viggo Mortensen", IdFilme = 6, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 19, Nome = "Orlando Bloom", IdFilme = 6, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 20, Nome = "Sean Astin", IdFilme = 6, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 21, Nome = "Keanu Reeves", IdFilme = 7, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 22, Nome = "Laurence Fishburne", IdFilme = 7, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 23, Nome = "Carrie-Anne Moss", IdFilme = 7, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 24, Nome = "Russell Crowe", IdFilme = 8, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 25, Nome = "Joaquin Phoenix", IdFilme = 8, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 26, Nome = "Connie Nielsen", IdFilme = 8, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 27, Nome = "Marlon Brando", IdFilme = 9, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 28, Nome = "Al Pacino", IdFilme = 9, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 29, Nome = "James Caan", IdFilme = 9, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 30, Nome = "Tom Hanks", IdFilme = 10, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 31, Nome = "Robin Wright", IdFilme = 10, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 32, Nome = "Gary Sinise", IdFilme = 10, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 33, Nome = "John Travolta", IdFilme = 11, Premios = new List < string > { "SAG Awards", "Black Reel Awards" }},
        new(){Id = 34, Nome = "Uma Thurman", IdFilme = 11, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 35, Nome = "Samuel L. Jackson", IdFilme = 11, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 36, Nome = "Christian Bale", IdFilme = 12,Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 37, Nome = "Heath Ledger", IdFilme = 12, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}},
        new(){Id = 38, Nome = "Aaron Eckhart", IdFilme = 12, Premios = new List<string>{ "SAG Awards", "Black Reel Awards"}}
    });
    private static readonly Lazy<List<Usuario>> instanciaUsuario = new(() => new List<Usuario>()
    {
        new(){Nome = "Gabriel Detofol", IdUsuario = 1, Plano = PlanoEnum.Premium, Senha = "123", NickName = "Detofol29"},
        new(){Nome = "Marcos Paulo", IdUsuario = 2, Plano = PlanoEnum.Nerd, Senha = "123", NickName = "SilvaMarcosPaulo"},
        new(){Nome = "Rubens", IdUsuario = 3, Plano = PlanoEnum.Kids, Senha = "123", NickName = "DarthRubens"},
        new(){Nome = "André", IdUsuario = 4, Plano = PlanoEnum.Free, Senha = "123", NickName = "AndrezinDoGrau"}
    });
    
    private TabelasSingleton()
    {
    }

    public static List<Filme> ObterInstanciaFilmes => instanciaFilme.Value;
    public static List<Ator> ObterInstanciaAtores => instanciaAtor.Value;
    public static List<Usuario> ObterInstanciaUsuarios => instanciaUsuario.Value;
}