using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes;

[Migration(20240705001230)]
public class Migracao20240705001230_CriaTabelaUsuarios_Filmes_Atores : Migration
{
    public override void Up()
    {
        Create.Table("Usuarios")
            .WithColumn("IdUsuario").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("Plano").AsInt32().NotNullable()
            .WithColumn("FilmesDoUsuario").AsInt32()
            .WithColumn("Senha").AsString().NotNullable()
            .WithColumn("NickName").AsString().NotNullable();
        Create.Table("Filmes")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Titulo").AsString().NotNullable()
            .WithColumn("DataDeLancamento").AsDateTime()
            .WithColumn("Genero").AsInt32()
            .WithColumn("EmCartaz").AsBoolean()
            .WithColumn("Nota").AsDecimal()
            .WithColumn("Duracao").AsInt32()
            .WithColumn("DisponivelNoPlano").AsBoolean()
            .WithColumn("Diretor").AsString()
            .WithColumn("Classificacao").AsInt32();
        Create.Table("Atores")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Nome").AsString().NotNullable()
            .WithColumn("IdFilme").AsInt32()
            .WithColumn("Premios").AsString();
        Create.Table("FilmesDoUsuario")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("IdUsuario").AsInt32()
            .WithColumn("IdFilme").AsInt32();

        Create.ForeignKey("FK_FilmesDoUsuario_Usuarios")
            .FromTable("FilmesDoUsuario").ForeignColumn("IdUsuario")
            .ToTable("Usuarios").PrimaryColumn("IdUsuario");

        Create.ForeignKey("FK_FilmesDoUsuario_Filmes")
            .FromTable("FilmesDoUsuario").ForeignColumn("IdFilme")
            .ToTable("Filmes").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("Usuarios");
        Delete.Table("Filmes");
        Delete.Table("Atores");
        Delete.Table("FilmesDoUsuario");
    }
}
