using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Modelos;

public enum ClassificacaoIndicativa
{
    [Description("Livre")]
    livre,
    [Description("10+")]
    dez,
    [Description("12+")]
    doze,
    [Description("14+")]
    quatorze,
    [Description("16+")]
    dezesseis,
    [Description("18+")]
    dezoito
}