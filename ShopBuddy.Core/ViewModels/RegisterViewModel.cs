namespace ShopBuddy.Core.ViewModels;
public class RegisterViewModel: BaseViewModel
{
    private readonly AppDbContextFactory _dbFactory; 
    private readonly NavigationStore _navigationStore;
    public ICommand RegisterUserCommand{ get; set; }

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

    private string _email;
    public string Email
    {
        get => _email;
        set => OnPropertyChanged(ref _email, value);
    }


    public RegisterViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
    {
        _dbFactory = dbFactory;
        _navigationStore = navigationStore;
        RegisterUserCommand = new RelayCommand(RegisterUser);
    }

    public void RegisterUser()
    {
        using var db = _dbFactory.CreateDbContext();
        var user = db.AppUsers.Where(x => x.Username == Username).FirstOrDefault();
        if (user == null) // user is null , meaning there is no such user so we can create a new user //
        {
            var _securityService = new SecurityService();
            var salt = _securityService.GenerateSalt();
            var hasedPassword = _securityService.Hash(Password, salt); //TODO: we need to handle null pointer here
            var newUser = new ApplicationUser()
            {
                Username = Username,
                Email = Email,
                UserGuid = _securityService.CreateUserGuid(),
                PasswordHash = hasedPassword,
                Salt = salt,
                Rank = Rank.MEMBER,
                IsLoggedIn = false
            };
            db.AppUsers.Add(newUser);
            db.SaveChanges();
            Username = "";
            Password = "";
            Email = "";
        }
        else
        {
            //TODO: send system message to warn user of failed register attempt.
            _navigationStore.CurrentViewModel = new LoginViewModel(_dbFactory, _navigationStore);
        }
            
    }
}

