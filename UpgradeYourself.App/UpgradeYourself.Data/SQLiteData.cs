namespace UpgradeYourself.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SQLite;
    using global::Windows.Storage;

    using UpgradeYourself.Common;
    using Models.Models;

    public class SQLiteData
    {
        private SQLiteAsyncConnection conn;

        public SQLiteData()
            : this(new SQLiteAsyncConnection(GlobalConstants.DbName))
        {
        }

        public SQLiteData(SQLiteAsyncConnection conn)
        {
            this.conn = conn;
        }

        public async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        public async Task CreateDatabaseAsync<T>() where T : new()
        {
            await this.conn.CreateTableAsync<T>();
        }

        public async Task AddAsync<T>(T model)
        {
            await this.conn.InsertAsync(model);
        }

        public async Task AddMultipleAsync<T>(ICollection<T> modelCollection)
        {
            await this.conn.InsertAllAsync(modelCollection);
        }

        // TODO update
        public T FindAsync<T>(int id) where T : BaseModel, new()
        {
            AsyncTableQuery<T> query = this.conn.Table<T>().Where(x => x.Id == id);
            return query.ToListAsync().Result.FirstOrDefault();
        }

        public async Task DeleteAsync<T>(T model) where T : BaseModel, new()
        {
            var item = await this.conn.Table<T>().Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (item != null)
            {
                await this.conn.DeleteAsync(item);
            }
        }

        public async Task DropTableAsync<T>() where T : new()
        {
            await this.conn.DropTableAsync<T>();
        }
    }
}
