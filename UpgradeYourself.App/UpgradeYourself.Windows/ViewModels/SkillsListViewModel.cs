namespace UpgradeYourself.Windows.ViewModels
{
    using System.Collections.Generic;

    using UpgradeYourself.Models.Models;

    public class SkillsListViewModel
    {      
        public ICollection<SkillViewModel> Skills { get; set; }
    }
}
