﻿using System;
using System.Collections.Generic;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Xunit.Microsoft.DependencyInjection;

namespace Cod3rsGrowth.Teste;

public class ModuloInjecao
{
    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();
        services.AddScoped<IAtorServico, AtorServicos>();
        return services.BuildServiceProvider(); 
     }
}