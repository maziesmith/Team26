namespace UpgradeYourself.Windows.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserProfileViewModel
    {
        // TODO: map from user? - from summary skill
        public UserProfileViewModel()
        {
            this.LevelsPassed = new Dictionary<string, List<int>>();
            this.Points = new Dictionary<string, int>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public IDictionary<string, List<int>> LevelsPassed { get; set; }

        public IDictionary<string, int> Points { get; set; }

        public void AddLevelToSkill(string skill, int level)
        {
            if (!this.LevelsPassed.ContainsKey(skill))
            {
                this.LevelsPassed[skill] = new List<int>();
            }

            this.LevelsPassed[skill].Add(level);
        }

        public void AddPointsToSkill(string skill, int points)
        {
            if (!this.Points.ContainsKey(skill))
            {
                this.Points[skill] = 0;
            }

            this.Points[skill] += points;
        }
    }
}
