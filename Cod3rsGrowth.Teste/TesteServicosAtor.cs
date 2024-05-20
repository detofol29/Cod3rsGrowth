using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Cod3rsGrowth.Teste;

public class TesteServicosAtor : TesteBase
{
    private readonly ServiceProvider ServiceProvider;
    public IAtorServico atorServico;

    public TesteServicosAtor()
    {
        ServiceProvider = base.ServiceProvider;
        atorServico = ServiceProvider.GetService<IAtorServico>();

    }

    [Fact]
    public void TesteRetornaListaDePremiosDoAtor()
    {
       
    }
}