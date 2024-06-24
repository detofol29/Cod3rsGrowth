using LinqToDB.Mapping;
namespace Cod3rsGrowth.Dominio.Modelos;

[Table("Usuarios")]
public class Usuario
{
    [Column("Nome"), NotNull]
    public string Nome { get; set; }
    [PrimaryKey, Identity]
    public int IdUsuario { get; set; }
    [Column("MinhaLista")]
    public List<Filme>? MinhaLista { get; set; }
    [Column("Plano")]
    public PlanoEnum Plano { get; set; }
    [Column("Senha")]
    public string Senha {  get; set; }
    [Column("NickName")]
    public string NickName { get; set; }
}