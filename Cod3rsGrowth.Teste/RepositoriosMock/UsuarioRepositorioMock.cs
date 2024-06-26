using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Teste.ClassesSingleton;
using Cod3rsGrowth.Dominio.Interfaces;
using Xunit.Sdk;
using Cod3rsGrowth.Dominio.Filtros;

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
        try
        {
            return tabelasSingleton.FirstOrDefault(a => a.IdUsuario == id) ?? throw new Exception("Usuario nao encontrado");
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Inserir(Usuario usuario)
    {
        tabelasSingleton.Add(usuario);
    }

    public List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario)
    {
        IQueryable<Usuario> query = tabelasSingleton.AsQueryable();

        if (filtroUsuario?.FiltroPlano != null)
        {
            query = from a in query
                    where a.Plano == filtroUsuario.FiltroPlano
                    select a;
        }
        return query.ToList();
    }

    public void Remover(int id)
    {
        try
        {
            var usuario = ObterPorId(id);
            tabelasSingleton.Remove(usuario);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Editar(Usuario usuario)
    {
        try
        {
            var alterarUsuario = ObterPorId(usuario.IdUsuario);
            alterarUsuario.Nome = usuario.Nome;
            alterarUsuario.MinhaLista = usuario.MinhaLista;
            alterarUsuario.Plano = usuario.Plano;
            alterarUsuario.Senha = usuario.Senha;
            alterarUsuario.NickName = usuario.NickName;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}