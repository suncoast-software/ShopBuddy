namespace ShopBuddy.Services.Services;
public class Startup : IStartupService
{
    public void CreateDefaultHostBuilder()
    {
        Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
           // services.AddSingleton<AppDbContextFactory>();

        }).Build();
    }
}

