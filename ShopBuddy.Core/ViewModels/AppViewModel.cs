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
        public ICommand CloseCommand { get; set; }
        public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;


        public AppViewModel(AppDbContextFactory dbFactory, NavigationStore navigationStore)
        {
            _db = dbFactory;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            CloseCommand = new RelayCommand(CloseApplication);
            //NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigationStore, () => new HomeViewModel(_db, _navigationStore));
            //NavigateUsersCommand = new NavigateCommand<UsersViewModel>(_navigationStore, () => new UsersViewModel(_db, _navigationStore));
                            
        }

        private void CloseApplication()
        {
           Application.Current.Shutdown();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
