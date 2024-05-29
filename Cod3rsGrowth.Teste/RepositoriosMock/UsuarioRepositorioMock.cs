using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.RepositoriosMock;

public class UsuarioRepositorioMock : IUsuarioRepositorio
{
    private readonly List<Usuario> tabelasSingleton;

    public UsuarioRepositorioMock()
    {
        tabelasSingleton = TabelasSingleton.ObterInstanciaUsuarios;
    }

    public Usuario ObterPorId(int id)
    {
        return tabelasSingleton.FirstOrDefault(a => a.IdUsuario == id) ?? throw new Exception("Usuario nao encontrado");
    }

    public List<Usuario> ObterTodos()
    {
        return tabelasSingleton;
    }

    public void Adicionar(Usuario usuario)
    {
        tabelasSingleton.Add(usuario);
    }

    public void Remover(int id)
    {
        var usuario = ObterPorId(id);
        tabelasSingleton.Remove(usuario);
    }
}