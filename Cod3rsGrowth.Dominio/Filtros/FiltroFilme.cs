using Cod3rsGrowth.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Filtros;

public class FiltroFilme
{
    public GeneroEnum? FiltroGenero { get; set; }
    public ClassificacaoIndicativa? FiltroClassificacao { get; set; }
    public bool? FiltroDisponivelNoPlano { get; set; }
    public bool? FiltroEmCartaz { get; set; }
    public int? FiltroNotaMinima { get; set; }

}