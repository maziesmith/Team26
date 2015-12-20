using System.ComponentModel.DataAnnotations;

namespace UpgradeYourself.Models
{
    using System.Collections.Generic;

    public class Question
    {
        private ICollection<Answer> answers;

        public Question()
        {
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        [Required]
        public int Difficulty { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                this.answers = value;
            }
        }
    }
}
