namespace UpgradeYourself.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public bool IsCorrect { get; set; }
    }
}
