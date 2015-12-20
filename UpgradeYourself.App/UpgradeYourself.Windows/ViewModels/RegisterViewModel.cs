using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeYourself.Models.Models;

namespace UpgradeYourself.Windows.ViewModels
{
    public class RegisterViewModel : MainPageViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public async Task<bool> Register()
        {
            try
            {
                var user = new ParseUser()
                {
                    Username = this.Username,
                    Password = this.Password
                };

                await user.SignUpAsync();
                await ParseUser.LogInAsync(this.Username, this.Password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
