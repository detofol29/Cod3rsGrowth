using LinqToDB.Configuration;

namespace Cod3rsGrowth.Infra;

public class ConfiguracaoDaStringDeConexao : IConnectionStringSettings
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
    public string ProviderName { get; set; }
    public bool IsGlobal => false;
}