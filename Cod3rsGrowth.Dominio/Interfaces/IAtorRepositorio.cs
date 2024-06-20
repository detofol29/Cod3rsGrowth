using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IAtorRepositorio   
{
    Ator ObterPorId(int id);
    void Inserir(Ator ator);
    List<Ator> ObterTodos(FiltroAtor? filtroAtor);
    public void Remover(int id);
    public void Editar(Ator ator);
}