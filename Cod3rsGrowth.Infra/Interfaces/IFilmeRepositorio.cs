using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces;

public interface IFilmeRepositorio
{
    Filme ObterPorId(int id);
    List<Filme> ObterTodos();
    void Inserir(Filme filme);
}