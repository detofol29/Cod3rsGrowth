using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelaAtor
{
    private static TabelaAtor _instancia;

    private List<Ator> _atores;

    private TabelaAtor()
    {
        _atores = new List<Ator>
        {
            new() {Id = 1, Nome = "Samuel L. Jackson", IdFilme = 3},
            new() {Id = 2, Nome = "Ewan McGregor", IdFilme = 3},
            new() {Id = 3, Nome = "Natalie Portman", IdFilme = 3},
            new() {Id = 4, Nome = "Michael J. Fox", IdFilme = 1},
            new() {Id = 5, Nome = "Leonardo DiCaprio", IdFilme = 2}
        };
    }

    public static TabelaAtor Instance
    {
        get
        {
            if(_instancia == null)
            {
                _instancia = new TabelaAtor();
            }
            return _instancia;
        }
    }

    public List<Ator> Atores => _atores;
}
