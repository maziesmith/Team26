namespace UpgradeYourself.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using UpgradeYourself.Models;

    public class QuestionViewModel
    {
        public static Expression<Func<Question, QuestionViewModel>> FromQuestion
        {
            get
            {
                return q => new QuestionViewModel
                {
                    Id = q.Id,
                    Content = q.Content,
                    Category = q.Category.Name.ToString(),
                    Difficulty = q.Difficulty,
                    Answers = q.Answers.AsQueryable()
                    .Select(AnswerViewModel.FromAnswer)
                    .ToList()
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Category { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Content { get; set; }
        
        [Required]
        public int Difficulty { get; set; }

        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}