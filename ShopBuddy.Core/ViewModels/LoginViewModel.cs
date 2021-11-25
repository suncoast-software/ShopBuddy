namespace ShopBuddy.Core.ViewModels;
public class LoginViewModel : BaseViewModel
{
    private readonly NavigationStore? _navigationStore;
    private readonly AppDbContextFactory? _dbFactory;
    public ICommand LoginCommand { get; set; }
    public ICommand CancelCommand { get; set; }

    private string? _username;
    public string? Username
    {
        get => _username;
        set => OnPropertyChanged(ref _username, value);
    }

    private string? _password;
    public string? Password
    {
        get => _password;
        set => OnPropertyChanged(ref _password, value);
    }

    public LoginViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
    {
        _dbFactory = dbFactory;
        _navigationStore = navigationStore;
        LoginCommand = new RelayCommand(Login);
        CancelCommand = new RelayCommand(CancelLogin);
       
    }

    private void CancelLogin()
    { 
        _navigationStore.CurrentViewModel = new RegisterViewModel(_dbFactory, _navigationStore);
    }

    private void Login()
    {
        //TODO: Check for empty Values, confirm login , set HomeViewModel()
        var db = _dbFactory.CreateDbContext();
        var _securityService = new SecurityService();
        var user = db.AppUsers.Where(x => x.Username == Username).First();
        var salt = user.Salt ?? String.Empty;
        var hasedPassword = _securityService.Hash(Password, salt); //TODO: we need to handle null pointer here
        if (hasedPassword.Equals(user.PasswordHash))
        {
            user.IsLoggedIn = true;
            db.SaveChanges();
            _navigationStore.CurrentViewModel = new HomeViewModel(_dbFactory, _navigationStore);
        }
            
    }
}

