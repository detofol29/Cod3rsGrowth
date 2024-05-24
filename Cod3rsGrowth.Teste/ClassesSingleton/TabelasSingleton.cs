using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelasSingleton
{
    private static List<Filme> instanciaFilme;
    private static List<Ator> instanciaAtor;
    private static List<Usuario> instanciaUsuario;


    private List<Filme> filmes;
    private List<Ator> atores;
    private List<Usuario> usuarios;

    private TabelasSingleton()
    {
        filmes = new List<Filme>();
        atores = new List<Ator>();
        usuarios = new List<Usuario>();
    }
    public static List<Filme> InstanceFilme
    {
        get
        {
            if(instanciaFilme == null)
            {
                instanciaFilme = new TabelasSingleton().Filmes;
            }
            return instanciaFilme;
        }
    }
    
    public static List<Ator> InstanceAtor
    {
        get
        {
            if(instanciaAtor == null)
            {
                instanciaAtor = new TabelasSingleton().Atores;
            }
            return instanciaAtor;
        }
    }
    public static List<Usuario> InstanceUsuario
    {
        get
        {
            if(instanciaUsuario == null)
            {
                instanciaUsuario = new TabelasSingleton().Usuarios;
            }
            return instanciaUsuario;
        }
    }
    public List<Filme> Filmes => filmes;
    public List<Ator> Atores => atores;
    public List<Usuario>Usuarios => usuarios;
}
