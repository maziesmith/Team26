namespace UpgradeYourself.Windows.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Models.Models;

    public class SkillViewModel
    {
        //public static Expression<Func<Skill, SkillViewModel>> FromSkill
        //{
        //    get
        //    {
        //        return q => new SkillViewModel
        //        {
        //            Name = q.Name,
        //            Description = q.Description,
        //            ImageUrl = q.ImageUrl
        //        };
        //    }
        //}

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
