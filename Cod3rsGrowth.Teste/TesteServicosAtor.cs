using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;


namespace Cod3rsGrowth.Teste;

public class TesteServicosAtor : TesteBase
{
    public AtorServicos atorServico;

    public TesteServicosAtor()
    {
        atorServico = ServiceProvider.GetService<AtorServicos>();
        if(atorServico == null)
        {
            throw new Exception();
        }
    }

    [Fact]
    public void TesteRetornaListaDePremiosDoAtor()
    {
       
    }
}