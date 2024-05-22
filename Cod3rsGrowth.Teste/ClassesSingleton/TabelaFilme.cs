using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelaFilme
{
    // Instância única da classe, inicializada como null
    private static TabelaFilme _instancia;

    private List<Filme> _filmes;

    //Construtor privado para evitar instancia paralela
    private TabelaFilme()
    {
        _filmes = new List<Filme>
        {
            new Filme { Id = 1, Titulo = "De Volta Para o Futuro", Genero = GeneroEnum.Ficcao },
            new Filme { Id = 2, Titulo = "Titanic", Genero = GeneroEnum.Romance },
            new Filme { Id = 3, Titulo = "Star Wars", Genero = GeneroEnum.Ficcao}
        };
    }
        //Faz a instancia da TabelaFilmes 
        public static TabelaFilme Instance
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new TabelaFilme();
                }
                return _instancia;
            }
        }
    public List<Filme> Filmes => _filmes;
}
