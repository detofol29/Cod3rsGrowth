using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelaFilme
{
    private static TabelaFilme instancia;

    private List<Filme> filmes;

    public List<Ator> AdicionarAtoresAoFilme(int idFilme)
    {
        var list = new List<Ator>();
        foreach(var ator in TabelaAtor.Instance.Atores)
        {
            if(ator.IdFilme == idFilme)
            {
                list.Add(ator);
            }
        }
        return list;
    }
    private TabelaFilme()
    {
        filmes = new List<Filme>
        {
            new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao, Atores = AdicionarAtoresAoFilme(1) },
            new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance, Atores = AdicionarAtoresAoFilme(2) },
            new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao, Atores = AdicionarAtoresAoFilme(3) },
            new Filme { Id = 4, Titulo = "O Senhor dos Anéis: A Sociedade do Anel", Genero = GeneroEnum.Fantasia, Atores = AdicionarAtoresAoFilme(4) },
            new Filme { Id = 5, Titulo = "O Senhor dos Anéis: As Duas Torres", Genero = GeneroEnum.Fantasia, Atores = AdicionarAtoresAoFilme(5) },
            new Filme { Id = 6, Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = GeneroEnum.Fantasia, Atores = AdicionarAtoresAoFilme(6) },
            new Filme { Id = 7, Titulo = "Matrix", Genero = GeneroEnum.Ficcao, Atores = AdicionarAtoresAoFilme(7) },
            new Filme { Id = 8, Titulo = "Gladiador", Genero = GeneroEnum.Acao, Atores = AdicionarAtoresAoFilme(8) },
            new Filme { Id = 9, Titulo = "O Poderoso Chefão", Genero = GeneroEnum.Drama, Atores = AdicionarAtoresAoFilme(9) },
            new Filme { Id = 10, Titulo = "Forrest Gump", Genero = GeneroEnum.Drama, Atores = AdicionarAtoresAoFilme(10) },
            new Filme { Id = 11, Titulo = "Pulp Fiction", Genero = GeneroEnum.Acao, Atores = AdicionarAtoresAoFilme(11) },
            new Filme { Id = 12, Titulo = "O Cavaleiro das Trevas", Genero = GeneroEnum.Acao, Atores = AdicionarAtoresAoFilme(12) }
        };

    }
    public static TabelaFilme Instance
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new TabelaFilme();
                }
                return instancia;
            }
        }
    public List<Filme> Filmes => filmes;
}