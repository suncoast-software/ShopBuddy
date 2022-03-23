using Microsoft.Extensions.Hosting;
using ShopBuddy.Core.UserControls;

namespace ShopBuddy.Core;
public partial class App : Application
{
    private readonly IHost _host;
    private readonly AppDbContextFactory _dbFactory;
    public App()
    {
        _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddTransient<AppDbContextFactory>();
            services.AddSingleton<ISecurity, SecurityService>();
            services.AddSingleton<NavigationStore>();
            services.AddTransient<AppViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<AppViewModel>()
            });
            services.AddSingleton<NavigationView>(s => new NavigationView()
            {
                DataContext = s.GetRequiredService<HomeViewModel>()
            });
        }).Build();

         _dbFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
       
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        NavigationStore navigationStore = _host.Services.GetRequiredService<NavigationStore>();
       
        var db = _dbFactory.CreateDbContext();
        var user = db.AppUsers.Any() ? db.AppUsers.First() : null;
        if (user is null)
        {
            navigationStore.CurrentViewModel = new RegisterViewModel(_dbFactory, navigationStore);
        }
        else
        {
            navigationStore.AppUser = user;
            user.IsLoggedIn = false;
            navigationStore.CurrentViewModel = new LoginViewModel(_dbFactory, navigationStore);
        }
            

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        var db = _dbFactory.CreateDbContext();
        var user = db.AppUsers.Any() ? db.AppUsers.First() : null;
        user.IsLoggedIn = false;
        db.SaveChanges();
        _host.Dispose();
        base.OnExit(e);
    }
}

