namespace UpgradeYourself.Data
{
    using System.Data.Entity;

    using UpgradeYourself.Data.Contracts;
    using UpgradeYourself.Data.Migrations;
    using UpgradeYourself.Models;

    public class UpgradeYourselfDbContext : DbContext, IUpgradeYourselfDbContext
    {
        public UpgradeYourselfDbContext()
            : base("UpgradeYourselfDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UpgradeYourselfDbContext, Configuration>());
        }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
