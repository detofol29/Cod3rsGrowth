﻿using System;

namespace Cod3rsGrowth_Dominio;

public class Filme
{
    public string Titulo { get; set; }
    public DateTime DataDeLancamento { get; set; }
    public Genero genero { get; set; } 
    public bool EmCartaz { get; set; }
    public Decimal Nota { get; set; }
    public int Duracao { get; set; }
    public bool DisponivelNoPlano { get; set; }
    public string Diretor { get; set; }
    public List<Ator> Atores {  get; set; }
}
