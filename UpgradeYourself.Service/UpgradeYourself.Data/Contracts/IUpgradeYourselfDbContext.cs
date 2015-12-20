namespace UpgradeYourself.Data.Contracts
{
    using System.Data.Entity;

    using UpgradeYourself.Models;

    public interface IUpgradeYourselfDbContext
    {
        IDbSet<Question> Questions { get; set; }

        IDbSet<Answer> Answers { get; set; }

        IDbSet<Category> Categories { get; set; }

        new IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}
