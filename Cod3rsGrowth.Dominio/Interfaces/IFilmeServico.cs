using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Interfaces;

public interface IFilmeServico
{
    List<IAtor> ObterAtoresDoFilme(Filme filme);
}
