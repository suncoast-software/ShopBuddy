namespace ShopBuddy.Core.ViewModels;
public class UsersViewModel: BaseViewModel
{
    private readonly AppDbContextFactory _dbFactory;
    private readonly NavigationStore _navigationStore;

    public UsersViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
    {
        _dbFactory = dbFactory;
        _navigationStore = navigationStore;
    }
}

