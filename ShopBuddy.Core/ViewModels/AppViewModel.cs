namespace ShopBuddy.Core.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly AppDbContext _db;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => OnPropertyChanged(ref _currentViewModel, value);
        }

        public AppViewModel(AppDbContextFactory db)
        {
            _db = db.CreateDbContext();
            var user = _db.AppUsers.Where(x => x.IsLoggedIn == true).FirstOrDefault();
            if (user == null)
                CurrentViewModel = new LoginViewModel();
           
        }
        private bool IsLoggedIn(ApplicationUser user)
        {
            return _db.AppUsers.Where(x => x.Username == user.Username).Any();
        }
       
    }
}
