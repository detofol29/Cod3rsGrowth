using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes;

[Migration(20240626001100)]
public class Migracao20240626001100_CriaTabelaUsuarios : Migration
{
    public override void Up()
    {
        Create.Table("Usuarios")
            .WithColumn("IdUsuario").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("Plano").AsString()
            .WithColumn("MinhaLista").AsString()
            .WithColumn("Senha").AsString()
            .WithColumn("NickName").AsString();
    }

    public override void Down()
    {
        Delete.Table("Usuarios");
    }
}