using LinqToDB.Mapping;
namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Usuarios")]
public class Usuario
{
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [PrimaryKey, Identity]
    public int IdUsuario { get; set; }
    public List<Filme>? FilmesDoUsuario { get; set; }
    [Column("Plano")]
    public PlanoEnum Plano { get; set; }
    [Column("Senha"), NotNull]
    public string Senha {  get; set; }
    [Column("NickName"), NotNull]
    public string NickName { get; set; }
    public string Hash { get; set; }
}