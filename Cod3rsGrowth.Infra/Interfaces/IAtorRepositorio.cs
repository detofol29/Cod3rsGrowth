using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IAtorRepositorio   
{
    Ator ObterPorId(int id);
    void Inserir(Ator ator);
    List<Ator> ObterTodos();
    public void Ordenar();
    public void Remover(int id);
}