using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Infra.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly ConexaoDados usuarioContexto;
    public UsuarioRepositorio(ConexaoDados _usuarioContexto)
    {
        usuarioContexto = _usuarioContexto;
    }
    public Usuario ObterPorId(int id)
    {
        return usuarioContexto.GetTable<Usuario>().FirstOrDefault(p => p.IdUsuario == id) ?? throw new Exception("Usuário não encontrado");
    }

    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        
        
            IQueryable<Usuario> query = from a in usuarioContexto.TabelaUsuario select a;

            if (filtroUsuario?.FiltroPlano != null)
            {
                query = from a in query
                        where a.Plano == filtroUsuario.FiltroPlano
                        select a;
            }

            if (filtroUsuario?.FiltroNome != null)
            {
                query = from a in query
                        where a.NickName == filtroUsuario.FiltroNome
                        select a;
            }
            return query.ToList();
        
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

    public ValidationResult CriarUsuario(Usuario usuario)
    {
        throw new ArgumentException();
    }
}