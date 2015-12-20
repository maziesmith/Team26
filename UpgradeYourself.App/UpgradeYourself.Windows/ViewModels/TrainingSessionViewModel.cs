namespace UpgradeYourself.Windows.ViewModels
{
    using System.Collections.Generic;

    using GalaSoft.MvvmLight;    
    
    public class TrainingSessionViewModel : ViewModelBase
    {
        private IList<QuestionViewModel> questions;
        private int currentIndex;
        private int points;

        public TrainingSessionViewModel()
        {
            this.questions = new List<QuestionViewModel>();
            this.CurrentQuestion = new QuestionViewModel();
        }

        public string Skill { get; set; }

        public int Level { get; set; }

        public int CurrentIndex
        {
            get
            {
                return this.currentIndex;
            }
            set
            {
                this.currentIndex = value;
                this.RaisePropertyChanged(() => this.CurrentIndex);
                this.RaisePropertyChanged(() => this.CurrentQuestion);
            }
        }

        public QuestionViewModel CurrentQuestion
        {
            get
            {
                if (this.questions.Count == 0 || this.CurrentIndex == this.questions.Count)
                {
                    return null;
                }

                return this.questions[this.CurrentIndex];
            }
            set
            {             
                this.RaisePropertyChanged(() => this.CurrentQuestion);
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
                this.RaisePropertyChanged(() => this.Points);
            }
        }

        public IList<QuestionViewModel> Questions
        {
            get
            {
                return this.questions;
            }

            set
            {
                this.questions = value;
            }
        }
    }
}
