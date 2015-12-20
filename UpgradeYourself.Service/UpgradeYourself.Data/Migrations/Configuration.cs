namespace UpgradeYourself.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<UpgradeYourself.Data.UpgradeYourselfDbContext>
    {
        private DataSeeder seeder;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.seeder = new DataSeeder();
        }

        protected override void Seed(UpgradeYourselfDbContext context)
        {
            if (!context.Categories.Any())
            {
                this.seeder.SeedCategories(context);
                this.seeder.SeedQuestions(context);
            }
        }
    }
}
