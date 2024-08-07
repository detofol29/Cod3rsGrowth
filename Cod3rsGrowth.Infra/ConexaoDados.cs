﻿using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra;

public class ConexaoDados : DataConnection
{
    public ConexaoDados(DataOptions<ConexaoDados> options) : base(options.Options) { }

    public ITable<Filme> TabelaFilme => this.GetTable<Filme>();
    public ITable<Ator> TabelaAtor => this.GetTable<Ator>();
    public ITable<Usuario> TabelaUsuario => this.GetTable<Usuario>();
    public ITable<FilmeDoUsuario> FilmesDoUsuario => this.GetTable<FilmeDoUsuario>();
}