using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Interfaces;

namespace Cod3rsGrowth.Teste;

public class TesteServicoFilme : TesteBase
{
    public IFilmeServico filmeServico;
    public TesteServicoFilme()
    {
        filmeServico = serviceProvider.GetService<IFilmeServico>() ?? throw new Exception("Serviço não foi encontrado");
    }
}