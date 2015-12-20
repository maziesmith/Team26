using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpgradeYourself.Windows.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UpgradeYourself.Windows.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
            //this.ViewModel = new RegisterViewModel();
        }

        public RegisterViewModel ViewModel
        {
            get
            {
                return this.DataContext as RegisterViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = e.Parameter as RegisterViewModel;
            //this.DataContext = e.Parameter;
        }

        private async void OnRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel == null)
            {
                // TODO: raise error
                return;
            }

            bool isValid = Validate(this.tbUsername.Text, this.tbPass.Password, this.tbConfirmPass.Password);

            bool isRegistered = await ViewModel.Register();
            if (isRegistered && isValid)
            {
                this.Frame.Navigate(typeof(SkillsPage));
            }
        }

        private bool Validate(string text, string password1, string password2)
        {
            this.UsernameCheck.Visibility = Visibility.Collapsed;
            this.PassCheck.Visibility = Visibility.Collapsed;
            this.ConfirmPassCheck.Visibility = Visibility.Collapsed;

            if (text.Length < 3 || text.Length > 20)
            {
                this.UsernameCheck.Visibility = Visibility.Visible;
                return false;
            }

            if (password1.Length < 3 || password1.Length > 20)
            {
                this.PassCheck.Visibility = Visibility.Visible;
                return false;
            }

            if (password1 != password2)
            {
                this.ConfirmPassCheck.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }
    }
}
