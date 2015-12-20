namespace UpgradeYourself.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using UpgradeYourself.Models;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return q => new CategoryViewModel
                {
                    Name = q.Name,
                    Description = q.Description,
                    ImageUrl = q.ImageUrl
                };
            }
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}