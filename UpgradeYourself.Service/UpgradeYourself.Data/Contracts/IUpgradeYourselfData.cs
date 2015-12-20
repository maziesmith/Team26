namespace UpgradeYourself.Data.Contracts
{
    using UpgradeYourself.Data.Repositories;
    using UpgradeYourself.Models;

    public interface IUpgradeYourselfData
    {
        IUpgradeYourselfDbContext Db { get; }

        IRepository<Question> Questions { get; }

        IRepository<Answer> Answers { get; }

        IRepository<Category> Categories { get; }

        void SaveChanges();
    }
}
