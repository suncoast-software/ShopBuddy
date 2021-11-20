namespace ShopBuddy.Services.Services;
public class DataService : IDataService
{
    public Config GetConfigurationJson()
    {
        var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "config.json");
        using var fs = File.OpenRead(configFile);
        using var sr = new StreamReader(fs, new UTF8Encoding(false));
        var json = sr.ReadToEnd();

        var configJson = JsonSerializer.Deserialize<Config>(json);

        return configJson;
    }
}

