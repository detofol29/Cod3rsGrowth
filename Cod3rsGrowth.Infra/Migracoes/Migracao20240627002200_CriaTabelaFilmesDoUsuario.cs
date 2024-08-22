using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes;

//[Migration(20240627002200)]
public class Migracao20240627002200_CriaTabelaFilmesDoUsuario : Migration
{
    public override void Up()
    {
        Create.Table("FilmesDoUsuario")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("IdUsuario").AsInt32()
            .WithColumn("IdFilme").AsInt32();
    }

    public override void Down()
    {
        Delete.Table("FilmesDoUsuario");
    }
}