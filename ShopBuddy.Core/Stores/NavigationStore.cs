namespace ShopBuddy.Core.Stores;

public class NavigationStore
{
    public event Action? CurrentViewModelChanged;
    public event Action? AppUserChanged;
    private BaseViewModel? _currentViewModel;
    public BaseViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private ApplicationUser _appUser;
    public ApplicationUser AppUser
    {
        get => _appUser;
        set
        {
            _appUser = value;
            OnAppUserChanged();
        }
    }

    private void OnAppUserChanged()
    {
        AppUserChanged?.Invoke();
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}

