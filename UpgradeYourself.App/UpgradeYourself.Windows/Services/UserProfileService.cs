namespace UpgradeYourself.Windows.Services
{
    using Models.Models;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UpgradeYourself.Common;

    public class UserProfileService
    {
        private SQLiteAsyncConnection conn;

        public UserProfileService()
            : this(new SQLiteAsyncConnection(GlobalConstants.DbName))
        {
        }

        public UserProfileService(SQLiteAsyncConnection conn)
        {
            this.conn = conn;
        }

        public async Task<ICollection<UserProfile>> GetUserProfiles()
        {
            var queryProfiles = this.conn.Table<UserProfile>();
            var userProfiles = await queryProfiles.ToListAsync();

            return userProfiles;
        }

        public async Task<UserProfile> GetCurrentUserProfile(string username)
        {
            var queryProfiles = this.conn.Table<UserProfile>();
            var userProfiles = await queryProfiles.ToListAsync();
            UserProfile currentUserProfile = userProfiles.FirstOrDefault(u => u.Username == username);

            return currentUserProfile;
        }
    }
}
