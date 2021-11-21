namespace ShopBuddy.Core.ViewModels;
public class LoginViewModel: BaseViewModel
{
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

    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(Login);
        CancelCommand = new RelayCommand(CancelLogin);
    }

    private void CancelLogin()
    {
        throw new NotImplementedException();
    }

    private void Login()
    {
        throw new NotImplementedException();
    }
}

