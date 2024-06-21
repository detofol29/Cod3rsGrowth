using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra;

public class ConexaoDados : DataConnection
{
    public ConexaoDados() : base("StreamingFilmesBD") { }

    public ITable<Filme> TabelaFilme => this.GetTable<Filme>();
    public ITable<Ator> TabelaAtor => this.GetTable<Ator>();
    public ITable<Usuario> TabelaUsuario => this.GetTable<Usuario>();
}
