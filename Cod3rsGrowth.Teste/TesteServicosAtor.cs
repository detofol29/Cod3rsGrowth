using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;


namespace Cod3rsGrowth.Teste;

public class TesteServicosAtor : TesteBase
{
    public AtorServicos atorServico;

    public TesteServicosAtor()
    {
        atorServico = serviceProvider.GetService<AtorServicos>() ?? throw new Exception("Serviço não foi encontrado");
    }

    [Fact]
    public void TesteRetornaListaDePremiosDoAtor()
    {
       
    }
}