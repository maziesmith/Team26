using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpgradeYourself.Windows.Pages;
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
using Windows.UI.Notifications;
using Windows.UI.Popups;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UpgradeYourself.Windows.Views
{
    public sealed partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            this.InitializeComponent();
        }

        private void OnLogOutButtonClick(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            (Window.Current.Content as Frame).Navigate(typeof(LogInPage));
        }

        private async void OnReminderButtonClicked(object sender, RoutedEventArgs e)
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();

            if (notifier.Setting != NotificationSetting.Enabled)
            {
                var dialog = new MessageDialog("Notifications are not enabled!");
                await dialog.ShowAsync();
                return;
            }

            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode("Practice regularly to stay fit!"));

            var date = DateTimeOffset.Now.AddSeconds(15);
            var stn = new ScheduledToastNotification(template, date);
            notifier.AddToSchedule(stn);
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            NavSplitView.IsPaneOpen = !NavSplitView.IsPaneOpen;
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(UserProfilePage));
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            (Window.Current.Content as Frame).Navigate(typeof(SkillsPage));
        }
    }
}
