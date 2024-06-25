using LinqToDB.Mapping;
using ColumnAttribute = System.ComponentModel.DataAnnotations.Schema.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

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