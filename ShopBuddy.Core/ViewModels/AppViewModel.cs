namespace ShopBuddy.Core.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly AppDbContextFactory _db;
        private readonly NavigationStore _navigationStore;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateInventoryCommand { get; }
        public ICommand NavigateUsersCommand { get; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public AppViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
        {
            _db = dbFactory;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateHomeCommand = new NavigateCommand<RegisterViewModel>(_navigationStore, () => new RegisterViewModel(_db, _navigationStore));
            
                     
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private bool IsLoggedIn(ApplicationUser user)
        {
            var db = _db.CreateDbContext();
            return db.AppUsers.Where(x => x.Username == user.Username).Any();
        }
       
    }
}
