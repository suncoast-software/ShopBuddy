namespace ShopBuddy.Core;
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<AppDbContextFactory>();
        services.AddSingleton<ISecurity, SecurityService>();
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<AppViewModel>();
        services.AddSingleton<MainWindow>(s => new MainWindow()
        {
           DataContext = s.GetRequiredService<AppViewModel>()
        });

        _serviceProvider = services.BuildServiceProvider();
       
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        NavigationStore navigationStore = _serviceProvider.GetRequiredService<NavigationStore>();
        AppDbContextFactory? dbFactory = _serviceProvider.GetService<AppDbContextFactory>();
        var db = dbFactory?.CreateDbContext();
        var user = db.AppUsers.Any() ? db.AppUsers.First() : null;
        if (user is null)
        {
            navigationStore.CurrentViewModel = new RegisterViewModel(navigationStore);
        }
        else
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);

        MainWindow = _serviceProvider.GetService<MainWindow>();
        MainWindow?.Show();
        base.OnStartup(e);
    }
}

