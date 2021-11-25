namespace ShopBuddy.Core.ViewModels;
public class LoginViewModel: BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    public ICommand LoginCommand { get; set; }
    public ICommand CancelCommand { get; set; }

    private string _username;
    public string Username
    {
        get => _username;
        set => OnPropertyChanged(ref _username, value);
    }

    private string _password;
    public string Password
    {
        get => _password;
        set => OnPropertyChanged(ref _password, value);
    }

    public LoginViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        LoginCommand = new RelayCommand(Login);
        CancelCommand = new RelayCommand(CancelLogin);
    }

    private void CancelLogin()
    {
        _navigationStore.CurrentViewModel = new RegisterViewModel(_navigationStore);
    }

    private void Login()
    {
        //TODO: confirm login , set HomeViewModel()
        _navigationStore.CurrentViewModel = new RegisterViewModel(_navigationStore);
    }
}

