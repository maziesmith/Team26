using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeYourself.Models.Models;

namespace UpgradeYourself.Windows.ViewModels
{
    public class LoginPageViewModel : MainPageViewModel
    {
        public LoginPageViewModel()
        {
            this.User = new UserProfile();
        }

        public UserProfile User { get; set; }

        public async Task<bool> Login()
        {
            try
            {
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
