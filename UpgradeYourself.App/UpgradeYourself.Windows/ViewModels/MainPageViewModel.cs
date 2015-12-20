namespace UpgradeYourself.Windows.ViewModels
{
    using Common;
    using GalaSoft.MvvmLight;
    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Controls;
    using Pages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MainPageViewModel : ViewModelBase
    {
        private ICommand goToRegisterCommand;
        private ICommand goToLogInCommand;

        public ICommand GoToLogInCommand
        {
            get
            {
                if (this.goToLogInCommand == null)
                {
                    this.goToLogInCommand = new DelegateCommand(this.GoToLogIn);
                }

                return this.goToLogInCommand;
            }
        }

        public ICommand GoToRegisterCommand
        {
            get
            {
                if (this.goToRegisterCommand == null)
                {
                    this.goToRegisterCommand = new DelegateCommand(this.GoToRegister);
                }

                return this.goToRegisterCommand;
            }
        }

        private void GoToRegister()
        {
            (Window.Current.Content as Frame).Navigate(typeof(RegisterPage), new RegisterViewModel());

            // TODO: figure out back button for partial pages and use this instead
            //this.Content = new RegisterContent();
        }

        private void GoToLogIn()
        {
            (Window.Current.Content as Frame).Navigate(typeof(LogInPage), new LoginPageViewModel());

            // TODO: figure out back button for partial pages and use this instead
            //this.Content = new LogInContent();
        }
    }
}
