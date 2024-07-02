using LinqToDB;
using LinqToDB.Configuration;

namespace Cod3rsGrowth.Infra;

public class ConfiguracaoConexao : ILinqToDBSettings
{
    public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

    public string DefaultConfiguration => "SqlServer";
    public string DefaultDataProvider => "SqlServer";

    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    {
        get
        {
            yield return
                new ConfiguracaoDaStringDeConexao
                {
                    Name = "StreamingFilmesBDL",
                    ProviderName = ProviderName.SqlServer,
                    ConnectionString = "Data Source=DESKTOP-G0T9JPL\\SQLEXPRESS;Initial Catalog=Cod3rsGrowth;User ID=sa;Password=sap@123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
                };
        }
    }
}