using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBuddy.Core.ViewModels
{
    public class AppViewModel
    {
        private readonly AppDbContextFactory _dbFactory;

        public AppViewModel(AppDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

    }
}
