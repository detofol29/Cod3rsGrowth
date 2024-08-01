using Cod3rsGrowth.Dominio.Enumeradores;
using Cod3rsGrowth.Dominio.Modelos;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Extensoes;

public static class ExtensaoDosEnuns
{
    public static T? ObterAtributoDoTipo<T>(this Enum valorEnum) where T : System.Attribute
    {
        var tipo = valorEnum.GetType();
        var informacaoDoMembro = tipo.GetMember(valorEnum.ToString());
        var atributos = informacaoDoMembro[0].GetCustomAttributes(typeof(T), false);
        return (atributos.Length > 0) 
            ? (T)atributos[0] 
            : null;
    }

    public static string ObterDescricao(this Enum valorEnum)
    {
       return valorEnum.ObterAtributoDoTipo<DescriptionAttribute>().Description;
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
        throw new Exception("Gênero não encontrado!"); 
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
        throw new Exception("Classificação não encontrada!");
    }
}