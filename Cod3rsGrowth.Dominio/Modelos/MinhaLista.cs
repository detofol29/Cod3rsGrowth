using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Async;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table ("MinhaLista")]
public class MinhaLista
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("IdUsuario"), NotNull]
    public int IdUsuario {  get; set; }
    [Column("IdFilme"), NotNull]
    public int IdFilme { get; set; }
    [Association(ThisKey = "IdUsuario", OtherKey = "IdUsuario", CanBeNull = false)]
    public Usuario Usuario { get; set; }
    [Association(ThisKey = "IdFilme", OtherKey = "Id", CanBeNull = false)]
    public Filme Filme { get; set; }
}