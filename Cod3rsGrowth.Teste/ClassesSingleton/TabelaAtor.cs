using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelaAtor
{
    private static TabelaAtor instancia;

    private List<Ator> atores;

    private TabelaAtor()
    {
        atores = new List<Ator>
        {
            new() {Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3},
            new() {Id = 2, Nome = "Ewan McGregor", IdFilme = 3},
            new() {Id = 3, Nome = "Natalie Portman", IdFilme = 3},
            new() {Id = 4, Nome = "Michael J. Fox", IdFilme = 1},
            new() {Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2},
            new() {Id = 6, Nome = "Elijah Wood", IdFilme = 4},
            new() {Id = 7, Nome = "Ian McKellen", IdFilme = 4},
            new() {Id = 8, Nome = "Viggo Mortensen", IdFilme = 4},
            new() {Id = 9, Nome = "Orlando Bloom", IdFilme = 4},
            new() {Id = 10, Nome = "Sean Astin", IdFilme = 4},
            new() {Id = 11, Nome = "Elijah Wood", IdFilme = 5},
            new() {Id = 12, Nome = "Ian McKellen", IdFilme = 5},
            new() {Id = 13, Nome = "Viggo Mortensen", IdFilme = 5},
            new() {Id = 14, Nome = "Orlando Bloom", IdFilme = 5},
            new() {Id = 15, Nome = "Sean Astin", IdFilme = 5},
            new() {Id = 16, Nome = "Elijah Wood", IdFilme = 6},
            new() {Id = 17, Nome = "Ian McKellen", IdFilme = 6},
            new() {Id = 18, Nome = "Viggo Mortensen", IdFilme = 6},
            new() {Id = 19, Nome = "Orlando Bloom", IdFilme = 6},
            new() {Id = 20, Nome = "Sean Astin", IdFilme = 6},
            new() {Id = 21, Nome = "Keanu Reeves", IdFilme = 7},
            new() {Id = 22, Nome = "Laurence Fishburne", IdFilme = 7},
            new() {Id = 23, Nome = "Carrie-Anne Moss", IdFilme = 7},
            new() {Id = 24, Nome = "Russell Crowe", IdFilme = 8},
            new() {Id = 25, Nome = "Joaquin Phoenix", IdFilme = 8},
            new() {Id = 26, Nome = "Connie Nielsen", IdFilme = 8},
            new() {Id = 27, Nome = "Marlon Brando", IdFilme = 9},
            new() {Id = 28, Nome = "Al Pacino", IdFilme = 9},
            new() {Id = 29, Nome = "James Caan", IdFilme = 9},
            new() {Id = 30, Nome = "Tom Hanks", IdFilme = 10},
            new() {Id = 31, Nome = "Robin Wright", IdFilme = 10},
            new() {Id = 32, Nome = "Gary Sinise", IdFilme = 10},
            new() {Id = 33, Nome = "John Travolta", IdFilme = 11},
            new() {Id = 34, Nome = "Uma Thurman", IdFilme = 11},
            new() {Id = 35, Nome = "Samuel L. Jackson", IdFilme = 11},
            new() {Id = 36, Nome = "Christian Bale", IdFilme = 12},
            new() {Id = 37, Nome = "Heath Ledger", IdFilme = 12},
            new() {Id = 38, Nome = "Aaron Eckhart", IdFilme = 12}
        };

    }
    public static TabelaAtor Instance
    {
        get
        {
            if(instancia == null)
            {
                instancia = new TabelaAtor();
            }
            return instancia;
        }
    }
    public List<Ator> Atores => atores;
}