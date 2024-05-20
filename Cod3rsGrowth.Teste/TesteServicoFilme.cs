﻿using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Interfaces;

namespace Cod3rsGrowth.Teste;

public class TesteServicoFilme : TesteBase
{
    [Fact]
    public void EncontrarFilmePorId_DeveRetornarFilme_QuandoFilmeExiste()
    {
        var repositorioFilme = serviceProvider.GetService<IFilmeRepositorio>();
        var filme = repositorioFilme.EncontrarFilmePorId(1);

        Assert.NotNull(filme);
        Assert.Equal(1, filme.Id);
        Assert.Equal("Star Wars", filme.Titulo);
    }
}
