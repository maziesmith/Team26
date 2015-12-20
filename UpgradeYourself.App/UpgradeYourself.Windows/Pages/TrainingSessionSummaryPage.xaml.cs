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
    public sealed partial class TrainingSessionSummaryPage : Page
    {
        public TrainingSessionSummaryPage()
            : this(new TrainingSessionSummaryViewModel())
        {
        }

        public TrainingSessionSummaryPage(TrainingSessionSummaryViewModel viewModel)
        {
            this.InitializeComponent();
            this.ViewModel = viewModel;
        }

        public TrainingSessionSummaryViewModel ViewModel
        {
            get
            {
                return this.DataContext as TrainingSessionSummaryViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as TrainingSessionSummaryViewModel;
            this.ViewModel.Skill = parameter.Skill;
            this.ViewModel.Level = parameter.Level;
            this.ViewModel.Points = parameter.Points;
        }

        private void OnTrainMoreButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SkillsPage));
        }
    }
}
