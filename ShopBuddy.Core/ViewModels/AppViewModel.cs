namespace ShopBuddy.Core.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly AppDbContext _db;
        private readonly ISecurity _security;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => OnPropertyChanged(ref _currentViewModel, value);
        }

        public AppViewModel(AppDbContextFactory db, ISecurity security)
        {
            _db = db.CreateDbContext();
            _security = security;
            var user = _db.AppUsers.Any() ? _db.AppUsers.First() : null;
            if (user is null )
            {
                CurrentViewModel = new RegisterViewModel(db, security);
            }
            else
                CurrentViewModel = new LoginViewModel();
           
        }
        private bool IsLoggedIn(ApplicationUser user)
        {
            return _db.AppUsers.Where(x => x.Username == user.Username).Any();
        }
       
    }
}
