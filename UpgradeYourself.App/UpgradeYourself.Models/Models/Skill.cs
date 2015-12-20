namespace UpgradeYourself.Models.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Skill")]
    public class Skill : BaseModel
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
