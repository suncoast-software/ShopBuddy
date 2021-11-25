namespace ShopBuddy.Core.ViewModels;
public class HomeViewModel: BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly AppDbContextFactory _dbFactory;

    private int _userCount;
    public int UserCount
    {
        get => _userCount;
        set => OnPropertyChanged(ref _userCount, value);
    }

    public HomeViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _dbFactory = dbFactory;
        UserCount = GetUserCount();
    }

    private int GetUserCount()
    {
        var db = _dbFactory.CreateDbContext();
        return db.AppUsers.Count();
    }
}

