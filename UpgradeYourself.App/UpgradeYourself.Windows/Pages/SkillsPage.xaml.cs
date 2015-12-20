using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpgradeYourself.Common;
using UpgradeYourself.Models.Models;
using UpgradeYourself.Windows.Services;
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
    public sealed partial class SkillsPage : Page
    {
        public SkillsPage()
            : this(new SkillsListViewModel())
        {
        }

        public SkillsPage(SkillsListViewModel viewModel)
        {
            this.InitializeComponent();
            this.ViewModel = viewModel;
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        public SkillsListViewModel ViewModel
        {
            get
            {
                return this.DataContext as SkillsListViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public void OnGridViewSkillItemClick(object sender, RoutedEventArgs e)
        {
            var textBlock = e.OriginalSource as TextBlock;
            if (textBlock == null)
            {
                var image = e.OriginalSource as Image;
                var parent = image.Parent as StackPanel;
                textBlock = parent.Children.Last() as TextBlock;
            }

            this.Frame.Navigate(typeof(SelectLevelPage), textBlock.Text);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //SQLiteAsyncConnection conn = new SQLiteAsyncConnection(GlobalConstants.DbName);
            //var querySkills = conn.Table<Skill>();
            //var skills = querySkills.ToListAsync().Result;

            //this.ViewModel.Skills = skills.AsQueryable()
            //    .Select(SkillViewModel.FromSkill)
            //    .ToList();

            this.ViewModel.Skills = this.GetSkills();
        }

        private ICollection<SkillViewModel> GetSkills()
        {
            var skillService = new SkillService();

            return skillService.GetSkills()
                .ToList();

            //  var questionsDifficulty = questionService.GetQuestionsInSkillWithDifficulty(skill, 0).ToList();

            //var session = new TrainingSessionViewModel()
            //{
            //    Skill = skill.Name,
            //    Questions = questions
            //};

            //this.DataContext = session;
        }
    }
}
