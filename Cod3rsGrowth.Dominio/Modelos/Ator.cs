namespace Cod3rsGrowth.Dominio.Modelos;
using LinqToDB.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Table("Atores")]
public class Ator
{
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("IdFilme"), NotNull]
    public int IdFilme { get; set; }
    [Column("Premios")]
    public List<string>? Premios { get; set; }
}