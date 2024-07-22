using Cod3rsGrowth.Dominio.Enumeradores;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Domuinio.Enumeradores;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Cod3rsGrowth.Dominio.Extensoes
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

        
        public static GeneroEnum ObterGeneroEnum(string descricao)
        {
            foreach (var genero in Enum.GetValues(typeof(GeneroEnum)))
            {
                if (ExtensaoDosEnuns.ObterDescricao((Enum)genero) == descricao)
                {
                    return (GeneroEnum)genero;
                };
            }
            throw new Exception("Genero nao encontrado!");
        }

        public static ClassificacaoIndicativa ObterClassificacaoEnum(string descricao)
        {
            switch (descricao)
            {
                case "Livre":
                    return ClassificacaoIndicativa.livre;
                case "10+":
                    return ClassificacaoIndicativa.dez;
                case "12+":
                    return ClassificacaoIndicativa.doze;
                case "14+":
                    return ClassificacaoIndicativa.quatorze;
                case "16+":
                    return ClassificacaoIndicativa.dezesseis;
                case "18+":
                    return ClassificacaoIndicativa.dezoito;
                default:
                    return ClassificacaoIndicativa.livre;
            }
        }

        public static GeneroEnum ConverterParaGeneroEnum(BaseParaEnumerador<GeneroEnum> baseEnum)
        {
            var generos = Enum.GetValues(typeof(GeneroEnum));
            foreach (var genero in generos)
            {
                if(ExtensaoDosEnuns.ObterDescricao((Enum)genero) == baseEnum.Descricao)
                {
                    return (GeneroEnum)(Enum)genero;
                }
            }
            throw new Exception("Genero nao encontrado"); 
        }

        public static ClassificacaoIndicativa ConverterParaClassificacaoEnum(BaseParaEnumerador<ClassificacaoIndicativa> baseEnum)
        {
            var classificacoes = Enum.GetValues(typeof(ClassificacaoIndicativa));
            foreach (var classificacao in classificacoes)
            {
                if (ExtensaoDosEnuns.ObterDescricao((Enum)classificacao) == baseEnum.Descricao)
                {
                    return (ClassificacaoIndicativa)(Enum)classificacao;
                }
            }
            throw new Exception("Classificacao nao encontrada");
        }
    }
}
