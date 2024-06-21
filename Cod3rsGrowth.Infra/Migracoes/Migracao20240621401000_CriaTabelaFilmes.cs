using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes;

[Migration(20240621401000)]
public class Migracao20240621401000_CriaTabelaFilmes : Migration
{
    public override void Up()
    {
        Create.Table("Filmes")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Titulo").AsString().NotNullable()
            .WithColumn("DataDeLancamento").AsDateTime()
	        .WithColumn("Genero").AsString()
	        .WithColumn("EmCartaz").AsBoolean()
            .WithColumn("Nota").AsDecimal()
	        .WithColumn("Duracao").AsInt32()
	        .WithColumn("DisponivelNoPlano").AsBoolean()
	        .WithColumn("Diretor").AsString()
	        .WithColumn("Classificacao").AsString()
	        .WithColumn("Atores");
    }

    public override void Down()
    {
        Delete.Table("Filmes");
    }
}