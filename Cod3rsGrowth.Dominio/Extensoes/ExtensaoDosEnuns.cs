using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth_Domínio.Extensoes
{
    public static class ExtensaoDosEnuns
    {
        public static T ObterAtributoDoTipo<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string ObterDescricao(this Enum valorEnum)
        {
            return valorEnum.ObterAtributoDoTipo<DescriptionAttribute>().Description;
        }
    }
}
