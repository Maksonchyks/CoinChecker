using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinChecker.Core;

namespace CoinChecker.Services.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<TPage>() where TPage : ViewModelBase;
    }
}
