namespace Cod3rsGrowth.Dominio.Modelos;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataDeLancamento { get; set; }
    public GeneroEnum Genero { get; set; }
    public bool EmCartaz { get; set; }
    public decimal Nota { get; set; }
    public int Duracao { get; set; }
    public bool DisponivelNoPlano { get; set; }
    public string Diretor { get; set; }
    public ClassificacaoIndicativa Classificacao { get; set; }
    public List<Ator> Atores { get; set; }
}