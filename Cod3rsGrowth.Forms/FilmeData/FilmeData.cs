using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth_Domínio.Extensoes;

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

    public FilmeData(Filme filme)
    {
        Id = filme.Id;
        Titulo = filme.Titulo;
        DataDeLancamento = filme.DataDeLancamento;
        Nota = filme.Nota;
        Duracao = filme.Duracao;
        Diretor = filme.Diretor;
        if(filme.DisponivelNoPlano == true)
        {
            DisponivelNoPlano = "Disponível";
        }
        else { DisponivelNoPlano = "Não Disponível"; }
        if(filme.EmCartaz == true)
        {
            EmCartaz = "Sim";
        }
        else
        {
            EmCartaz = "Não";
        }
        Genero = ExtensaoDosEnuns.ObterDescricao(filme.Genero);
        Classificacao = ExtensaoDosEnuns.ObterDescricao(filme.Classificacao);
    }
}