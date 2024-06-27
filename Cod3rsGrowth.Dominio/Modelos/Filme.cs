using FluentMigrator.Runner.VersionTableInfo;
using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = LinqToDB.Mapping.ColumnAttribute;
using TableAttribute = LinqToDB.Mapping.TableAttribute;

namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Filmes")]
public class Filme
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    [Column("Titulo")]
    public string Titulo { get; set; }
    [Column("DataDeLancamento")]
    public DateTime DataDeLancamento { get; set; }
    [Column("Genero")]
    public GeneroEnum Genero { get; set; }
    [Column("EmCartaz")]
    public bool EmCartaz { get; set; }
    [Column("Nota")]
    public decimal Nota { get; set; }
    [Column("Duracao")]
    public int Duracao { get; set; }
    [Column("DisponivelNoPlano")]
    public bool DisponivelNoPlano { get; set; }
    [LinqToDB.Mapping.Column("Diretor")]
    public string Diretor { get; set; }
    [Column("Classificacao")]
    public ClassificacaoIndicativa Classificacao { get; set; }
    public List<Ator>? Atores { get; set; }
}