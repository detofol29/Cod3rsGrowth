using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Interfaces;

public interface IUsuarioServicos
{
    void AdicionarFilmeNaMinhaLista(Filme filme, Usuario usuario);
}