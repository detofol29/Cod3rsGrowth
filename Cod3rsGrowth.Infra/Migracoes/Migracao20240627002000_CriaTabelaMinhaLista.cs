using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Migracoes;

[Migration(20240627002000)]
public class Migracao20240627002000_CriaTabelaMinhaLista : Migration
{
    public override void Up()
    {
        Create.Table("MinhaLista")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("IdUsuario").AsInt32()
            .WithColumn("IdFilme").AsInt32();
    }

    public override void Down()
    {
        Delete.Table("MinhaLista");
    }
}
