namespace ShopBuddy.Core.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly AppDbContext _db;
        private readonly NavigationStore _navigationStore;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateInventoryCommand { get; }
        public ICommand NavigateUsersCommand { get; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public AppViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            
                     
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private bool IsLoggedIn(ApplicationUser user)
        {
            return _db.AppUsers.Where(x => x.Username == user.Username).Any();
        }
       
    }
}
