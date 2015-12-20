namespace UpgradeYourself.Windows.ViewModels
{
    using GalaSoft.MvvmLight;
    using SQLite;

    //[Table("Answer")]
    public class AnswerViewModel : ViewModelBase
    {
        //public int QuestionId { get; set; }

        //[MaxLength(250)]
        public string Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}