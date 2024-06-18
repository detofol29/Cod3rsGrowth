using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly List<Usuario> tabelaUsuarios;
    public Usuario ObterPorId(int id)
    {
        try
        {
            return tabelaUsuarios.FirstOrDefault(a => a.IdUsuario == id) ?? throw new Exception("Id nao encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<Usuario> ObterTodos()
    {
        return tabelaUsuarios;
    }

    public void Inserir(Usuario usuario)
    {
        tabelaUsuarios.Add(usuario);
    }

    public void Remover(int id)
    {
        try
        {
            var usuario = ObterPorId(id);
            tabelaUsuarios.Remove(usuario);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(int id,  Usuario usuario)
    {
        try
        {
            var alterarUsuario = ObterPorId(id);
            alterarUsuario.Nome = usuario.Nome;
            alterarUsuario.MinhaLista = usuario.MinhaLista;
            alterarUsuario.Plano = usuario.Plano;
            alterarUsuario.Senha = usuario.Senha;
            alterarUsuario.NickName = usuario.NickName;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}