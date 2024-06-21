using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    ConexaoDados usuarioContexto = new();
    public Usuario ObterPorId(int id)
    {
        return usuarioContexto.GetTable<Usuario>().FirstOrDefault(p => p.IdUsuario == id) ?? throw new Exception("Usuário não encontrado");
    }

    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        using (var UsuarioContexto = new ConexaoDados())
        {
            IQueryable<Usuario> query = from a in UsuarioContexto.TabelaUsuario select a;

            if (filtroUsuario?.FiltroPlano != null)
            {
                query = from a in query
                        where a.Plano == filtroUsuario.FiltroPlano
                        select a;
            }
            return query.ToList();
        }
    }

    public void Inserir(Usuario usuario)
    {
        usuarioContexto.Insert(usuario);
    }

    public void Remover(int id)
    {
        var usuario = ObterPorId(id);
        usuarioContexto.Delete(usuario);
    }

    public void Editar(Usuario usuario)
    {
        usuarioContexto.Update(usuario);
    }
}