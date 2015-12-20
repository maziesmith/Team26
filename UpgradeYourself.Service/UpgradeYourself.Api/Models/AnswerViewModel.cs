namespace UpgradeYourself.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using UpgradeYourself.Models;

    public class AnswerViewModel
    {
        public static Expression<Func<Answer, AnswerViewModel>> FromAnswer
        {
            get
            {
                return q => new AnswerViewModel
                {
                    Id = q.Id,
                    Content = q.Content,
                    QuestionId = q.QuestionId,
                    IsCorrect = q.IsCorrect
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}