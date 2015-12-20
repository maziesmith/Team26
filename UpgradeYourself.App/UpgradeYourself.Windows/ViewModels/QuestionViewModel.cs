namespace UpgradeYourself.Windows.ViewModels
{
    using System.Collections.Generic;

    using SQLite;

    using Models;
    using GalaSoft.MvvmLight;

    public class QuestionViewModel : ViewModelBase
    {
        private ICollection<AnswerViewModel> answers;
        private string content;
        private string skill;

        public QuestionViewModel()
        {
            this.answers = new List<AnswerViewModel>();
        }

        public string Skill
        {
            get
            {
                return this.skill;
            }
            set
            {
                this.skill = value;
                this.RaisePropertyChanged(() => this.Skill);
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                this.RaisePropertyChanged(() => this.Content);
            }
        }

        public int Difficulty { get; set; }

        public ICollection<AnswerViewModel> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                this.answers = value;
                this.RaisePropertyChanged(() => this.Answers);
            }
        }
    }
}
