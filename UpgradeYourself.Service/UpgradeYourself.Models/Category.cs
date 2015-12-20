namespace UpgradeYourself.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
