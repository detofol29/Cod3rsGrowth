using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Migracoes;

//[Migration(20240627002100)]
public class Migracao20240627002100_AdicionaChaveEstrangeira : Migration
{
    public override void Up()
    {
        Create.ForeignKey("FK_MinhaLista_Usuarios")
            .FromTable("MinhaLista").ForeignColumn("IdUsuario")
            .ToTable("Usuarios").PrimaryColumn("IdUsuario");

        Create.ForeignKey("FK_MinhaLista_Filmes")
            .FromTable("MinhaLista").ForeignColumn("IdFilme")
            .ToTable("Filmes").PrimaryColumn("Id");
    }

    public override void Down() 
    {
        Delete.ForeignKey("FK_MinhaLista_Usuarios");
    }
}
