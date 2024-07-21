using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Extensoes;

namespace Cod3rsGrowth.Forms;

public class FilmeData
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataDeLancamento { get; set; }
    public string Genero { get; set; }
    public string EmCartaz { get; set; }
    public decimal Nota { get; set; }
    public int Duracao { get; set; }
    public string DisponivelNoPlano { get; set; }
    public string Diretor { get; set; }
    public string Classificacao { get; set; }
}