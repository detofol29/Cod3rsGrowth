using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using System.Runtime.CompilerServices;
using Cod3rsGrowth.Dominio.Modelos;
using NuGet.Frameworks;
using Cod3rsGrowth.Teste.ClassesSingleton;

namespace Cod3rsGrowth.Teste;

public class TesteServicoFilme : TesteBase
{
    public IFilmeServico filmeServico;
    public TesteServicoFilme()
    {
        filmeServico = serviceProvider.GetService<IFilmeServico>() ?? throw new Exception("Serviço não foi encontrado");
    }
}