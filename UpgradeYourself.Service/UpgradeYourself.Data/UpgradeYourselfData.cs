namespace UpgradeYourself.Data
{
    using System;
    using System.Collections.Generic;

    using UpgradeYourself.Data.Contracts;
    using UpgradeYourself.Data.Repositories;
    using UpgradeYourself.Models;

    public class UpgradeYourselfData : IUpgradeYourselfData
    {
        private IUpgradeYourselfDbContext db;
        private IDictionary<Type, object> repositories;

        public UpgradeYourselfData(IUpgradeYourselfDbContext db)
        {
            this.db = db;
            this.repositories = new Dictionary<Type, object>();
        }

        public IUpgradeYourselfDbContext Db
        {
            get 
            { 
                return this.db;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                return this.GetRepository<Question>();
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                return this.GetRepository<Answer>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var type = typeof(GenericRepository<T>);
                var newRepository = Activator.CreateInstance(type, this.db);

                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
