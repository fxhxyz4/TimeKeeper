using Microsoft.Extensions.Configuration;

namespace TimeKeeper.Modules.Utils;

public class RabbitConfig
{
    private static readonly string _settingsFile = "appsettings.json";

    public IConfiguration Configuration { get; private set; }

    public RabbitConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(_settingsFile, optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }
}
