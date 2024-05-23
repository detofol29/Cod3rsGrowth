using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelasSingleton
{
    private static TabelasSingleton instancia;

    private List<Filme> filmes;
    private List<Ator> atores;
    private List<Usuario> usuarios;

    public List<Ator> AdicionarAtoresAoFilme(int idFilme)
    {
        var list = new List<Ator>();
        foreach (var ator in atores)
        {
            if (ator.IdFilme == idFilme)
            {
                list.Add(ator);
            }
        }
        return list;
    }
    private TabelasSingleton()
    {
        filmes = new List<Filme>();
        atores = new List<Ator>();
        usuarios = new List<Usuario>();
    }
    public static TabelasSingleton Instance
    {
        get
        {
            if (instancia == null)
            {
                instancia = new TabelasSingleton();
            }
            return instancia;
        }
    }
    public List<Filme> Filmes => filmes;
    public List<Ator> Atores => atores;
    public List<Usuario> Usuarios => usuarios;
}
