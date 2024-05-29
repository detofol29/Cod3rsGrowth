using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IAtorRepositorio   
{
    Ator ObterPorId(int id);

    List<Ator> ObterTodos();
}