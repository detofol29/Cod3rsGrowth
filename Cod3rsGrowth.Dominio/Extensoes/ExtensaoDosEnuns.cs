using Cod3rsGrowth.Dominio.Modelos;
using System.ComponentModel;

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
            switch (descricao)
            {
                case "Terror":
                    return GeneroEnum.Terror;
                case "Ficção":
                    return GeneroEnum.Ficcao;
                case "Ação":
                    return GeneroEnum.Acao;
                case "Romance":
                    return GeneroEnum.Romance;
                case "Drama":
                    return GeneroEnum.Drama;
                case "Aventura":
                    return GeneroEnum.Aventura;
                case "Comédia":
                    return GeneroEnum.Comedia;
                case "Fantasia":
                    return GeneroEnum.Fantasia;
                default:
                    return GeneroEnum.Acao;
            }
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
    }
}
