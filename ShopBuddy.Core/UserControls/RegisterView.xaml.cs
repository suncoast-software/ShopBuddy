using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopBuddy.Core.UserControls
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        private readonly AppDbContextFactory _db;
        private readonly ISecurity _security;
        public RegisterView(AppDbContextFactory db, ISecurity security)
        {
            InitializeComponent();
            _db = db;
            _security = security;
            DataContext = new RegisterViewModel(_db, _security);
        }

        public RegisterView()
        {
            InitializeComponent();
        }
    }
}
