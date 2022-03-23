namespace ShopBuddy.Core.ViewModels;
public class HomeViewModel: BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly AppDbContextFactory _dbFactory;

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateSettingsCommand { get; }
    public ICommand NavigateInventoryCommand { get; }
    public ICommand NavigateUsersCommand { get; }
    public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    private int _userCount;
    public int UserCount
    {
        get => _userCount;
        set => OnPropertyChanged(ref _userCount, value);
    }

    private bool _loggedIn;
    public bool LoggedIn
    {
        get => _loggedIn;
        set => OnPropertyChanged(ref _loggedIn, value);
    }

    public HomeViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _dbFactory = dbFactory;
        if (_navigationStore.AppUser is not null)
            LoggedIn = _navigationStore.AppUser.IsLoggedIn;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigationStore, () => new HomeViewModel(_dbFactory, _navigationStore));
        NavigateUsersCommand = new NavigateCommand<UsersViewModel>(_navigationStore, () => new UsersViewModel(_dbFactory, _navigationStore));
        UserCount = GetUserCount();
    }

    private int GetUserCount()
    {
        var db = _dbFactory.CreateDbContext();
        return db.AppUsers.Count();
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
    
    
}

