using System;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Teste.ClassesSingleton;

public class TabelasSingleton
{
    private static readonly Lazy<List<Filme>> instanciaFilme = new(() => new List<Filme>());
    private static readonly Lazy<List<Ator>> instanciaAtor = new(() => new List<Ator>());
    private static readonly Lazy<List<Usuario>> instanciaUsuario = new(() => new List<Usuario>());

    private TabelasSingleton()
    {
    }

    public static List<Filme> ObterInstacniaFilmes => instanciaFilme.Value;
    public static List<Ator> ObterInstanciaAtores => instanciaAtor.Value;
    public static List<Usuario> ObterInstanciaUsuarios => instanciaUsuario.Value;
}