using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IUsuarioRepositorio  
{
    Usuario ObterPorId(int id);
    void Inserir(Usuario usuario);
    List<Usuario> ObterTodos();
    public void Remover(int id);
    public void Editar(int id, Usuario usuario);
}