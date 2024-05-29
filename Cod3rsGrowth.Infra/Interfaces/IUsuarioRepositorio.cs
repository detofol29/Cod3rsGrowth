using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IUsuarioRepositorio  
{
     Usuario ObterPorId(int id);

    List<Usuario> ObterTodos();
}