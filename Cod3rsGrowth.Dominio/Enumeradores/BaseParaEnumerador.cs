using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Enumeradores
{
    public class BaseParaEnumerador<TEnum>
    {
        public TEnum Id { get; set; }
        public string Descricao { get; set; }
    }
}
