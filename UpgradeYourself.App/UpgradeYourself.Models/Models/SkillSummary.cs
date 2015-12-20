namespace UpgradeYourself.Models.Models
{
    using SQLite;

    [Table("SkillSummary")]
    public class SkillSummary
    {
        public string Username { get; set; }

        public string Skill { get; set; }

        public int Level { get; set; }

        public int Points { get; set; }
    }
}
