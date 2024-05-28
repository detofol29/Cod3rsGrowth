using Cod3rsGrowth.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Teste;

public class TesteServicosAtor : TesteBase
{
    public IAtorServico atorServico;

    public TesteServicosAtor()
    {
        atorServico = serviceProvider.GetService<IAtorServico>() ?? throw new Exception("Serviço não foi encontrado");
    }
}