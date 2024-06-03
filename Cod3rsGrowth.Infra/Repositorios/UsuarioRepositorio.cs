using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly List<Usuario> tabelaUsuarios;
    public Usuario ObterPorId(int id)
    {
        return tabelaUsuarios.FirstOrDefault(a => a.IdUsuario == id) ?? throw new Exception("Id nao encontrado");
    }

    public List<Usuario> ObterTodos()
    {
        return tabelaUsuarios;
    }

    public void Inserir(Usuario usuario)
    {
        tabelaUsuarios.Add(usuario);
    }


    public void Adicionar(Usuario usuario)
    {
        tabelaUsuarios.Add(usuario);
    }

    public void Remover(int id)
    {
        var usuario = ObterPorId(id);
        tabelaUsuarios.Remove(usuario);
    }
}