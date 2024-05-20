<<<<<<< HEAD
﻿using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Servicos;

public class FilmeServicos : IFilmeServico
{
    List<IAtor> IFilmeServico.ObterAtoresDoFilme(Filme filme)
    {
        var list = new List<IAtor>();
        foreach(var ator in filme.Atores)
        {
            list.Add(ator);
        }
        return list;
    }
}
=======
﻿using System;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Servicos;

public class FilmeServicos : IFilmeServicos
{
   
}
>>>>>>> 7c31adb2fe8c0eba90fb0a7cb563f8461ae8f424
