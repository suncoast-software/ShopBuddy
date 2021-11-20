namespace ShopBuddy.Services.Services;
public class Startup : IStartupService
{
    public IHost? _host;

    public IHost CreatDefaultHostBuilder()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {

            }).Build();
        return _host;
    }
}

