using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpgradeYourself.Common;
using UpgradeYourself.Data;
using UpgradeYourself.Models.Models;
using UpgradeYourself.Windows.Services;
using UpgradeYourself.Windows.ViewModels;
using UpgradeYourself.BackgroundTask;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UpgradeYourself.Windows.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SQLiteData sqliteData;
        private DataSeeder dataSeeder;

        public MainPage()
        {
            this.InitializeComponent();
            this.sqliteData = new SQLiteData();
            this.dataSeeder = new DataSeeder(this.sqliteData);
            this.DataContext = new MainPageViewModel();

            //var skill = new Skill()
            //{
            //    Name = "JavaScript"
            //};
            //GetTrainingSession(skill);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // drop tables to test
            // await this.sqliteData.DropTableAsync<UserProfile>();
            // await this.sqliteData.DropTableAsync<Skill>();

            // Create Db if not exist

            bool dbExists = await sqliteData.CheckDbAsync(GlobalConstants.DbName);
            if (!dbExists)
            {
                await sqliteData.CreateDatabaseAsync<SkillSummary>();
                await sqliteData.CreateDatabaseAsync<UserProfile>();
                //await sqliteData.CreateDatabaseAsync<Answer>();
                //await sqliteData.CreateDatabaseAsync<Question>();
                //await sqliteData.CreateDatabaseAsync<TrainingSession>();

                await dataSeeder.SeedUserProfile();
                //await dataSeeder.SeedSkills();
            }

            // test - get user profile TODO: remove

            //SQLiteAsyncConnection conn = new SQLiteAsyncConnection(GlobalConstants.DbName);
            //var queryProfiles = conn.Table<UserProfile>();
            //var userProfiles = await queryProfiles.ToListAsync();

            //var querySkills = conn.Table<Skill>();
            //var skills = await querySkills.ToListAsync();

            // show user
            //this.DataContext = userProfiles.FirstOrDefault();

            this.RegisterBackgroundTask();
        }

        private const string taskName = "LiveTileBackgroundTask";
        private const string taskEntryPoint = "UpgradeYourself.BackgroundTask.LiveTileBackgroundTask";

        private async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == taskName)
                    {
                        task.Value.Unregister(true);
                    }
                }

                BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = taskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger(new TimeTrigger(15, false));
                var registration = taskBuilder.Register();
            }
        }
    

        //private void GetTrainingSession(Skill skill)
        //{
        //    var questionService = new QuestionService();
        //    var questions = questionService.GetQuestionsInSkill(skill).ToList();
        //    var questionsDifficulty = questionService.GetQuestionsInSkillWithDifficulty(skill, 0).ToList();

        //    var session = new TrainingSessionViewModel()
        //    {
        //        Skill = skill.Name,
        //        Questions = questions
        //    };

        //    this.DataContext = session;
        //}

        //private void Navigate(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(TestPage));
        //}
    }
}
