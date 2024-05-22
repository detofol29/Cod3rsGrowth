using System;

namespace Cod3rsGrowth.Dominio.Modelos;

public class Usuario
{ 
    public string Nome { get; set; }
    public int IdUsuario { get; set; }
    public List<Filme> MinhaLista { get; set; }
    public PlanoEnum Plano { get; set; }
}