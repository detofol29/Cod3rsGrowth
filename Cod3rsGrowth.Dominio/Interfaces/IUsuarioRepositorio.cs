using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IUsuarioRepositorio  
{
    Usuario ObterPorId(int id);
    void Inserir(Usuario usuario);
    List<Usuario> ObterTodos(FiltroUsuario? filtroUsuario);
    void Remover(int id);
    void Editar(Usuario usuario);
}