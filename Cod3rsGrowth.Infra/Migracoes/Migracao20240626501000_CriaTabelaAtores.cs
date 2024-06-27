using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes;

[Migration(20240626501000)]
public class Migracao20240626501000_CriaTabelaAtores : Migration
{
    public override void Up()
    {
        Create.Table("Atores")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("IdFilme").AsInt32()
            .WithColumn("Premios").AsString();
    }

    public override void Down()
    {
        Delete.Table("Atores");
    }
}