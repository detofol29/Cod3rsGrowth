using Cod3rsGrowth.Dominio.Filtros;
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

    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        using (var UsuarioContexto = new ConexaoDados())
        {
            IQueryable<Usuario> query;

            query = from a in UsuarioContexto.TabelaUsuario select a;

            if(filtroUsuario == null)
            {
                return query.ToList();
            }
            else
            {
                if (filtroUsuario.FiltroPlano.HasValue)
                {
                    query = from a in query
                            where a.Plano == filtroUsuario.FiltroPlano
                            select a;
                }
                return query.ToList();
            }
        }
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