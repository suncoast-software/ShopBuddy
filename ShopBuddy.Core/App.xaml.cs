namespace ShopBuddy.Core;
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<AppDbContextFactory>();
        services.AddSingleton<ISecurity, SecurityService>();
        services.AddSingleton<AppViewModel>();
        services.AddSingleton<MainWindow>(s => new MainWindow()
        {
           DataContext = s.GetRequiredService<AppViewModel>()
        });

        _serviceProvider = services.BuildServiceProvider();
       
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = _serviceProvider.GetService<MainWindow>();
        MainWindow?.Show();
        base.OnStartup(e);
    }
}

