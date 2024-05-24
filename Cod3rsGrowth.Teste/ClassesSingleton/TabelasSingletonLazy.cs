using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelasSingletonLazy
{
    private static Lazy<TabelasSingletonLazy> instancia;

    private Lazy<List<Filme>> filmes;
    private Lazy<List<Ator>> atores;
    private Lazy<List<Usuario>> usuarios;

    private TabelasSingletonLazy()
    {
        filmes = new Lazy<List<Filme>>(() => new List<Filme>());
        atores = new Lazy<List<Ator>>(() => new List<Ator>());
        usuarios = new Lazy<List<Usuario>>(() => new List<Usuario>());
    }
    public static Lazy<TabelasSingletonLazy> Instance
    {
        get
        {
            if(instancia == null)
            {
                instancia = new Lazy<TabelasSingletonLazy>(() => new TabelasSingletonLazy());
            }
            return instancia;
        }
    }
    
    public Lazy<List<Filme>> Filmes => filmes;
    public Lazy<List<Ator>> Atores => atores;
    public Lazy<List<Usuario>> Usuarios => usuarios;
}
