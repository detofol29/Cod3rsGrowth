using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Modelos;

public enum GeneroEnum
{
    [Description("Ficção")]
    Ficcao,
    [Description("Ação")]
    Acao,
    [Description("Terror")]
    Terror,
    [Description("Romance")]
    Romance,
    [Description("Drama")]
    Drama,
    [Description("Aventura")]
    Aventura,
    [Description("Comédia")]
    Comedia,
    [Description("Fantasia")]
    Fantasia
}