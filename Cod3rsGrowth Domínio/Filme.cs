using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth_Dominio;

internal class Filme
{
    public string Titulo { get; set; }
    public DateTime DataDeLancamento { get; set; }
    public enum Genero {Fiction, Action, Horror, Romance, Drama, Adventure, Comady}
    public bool EmCartaz { get; set; }
    public Decimal Nota { get; set; }
    public int Duracao { get; set; }
    public bool DisponivelNoPlano { get; set; }
    public string Diretor { get; set; }
    public String[] Elenco {  get; set; }

    public Filme(string titulo, int duracao, bool disponivelPlano)
    {
        Titulo = titulo;
        Duracao = duracao;
        DisponivelNoPlano = disponivelPlano;
    }

    
}
