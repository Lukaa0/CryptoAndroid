using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace HandyCrypto.DataHelper
{
    public class DataHelper<T> where T : new() {
        private SQLiteAsyncConnection connection;
        string basePath= System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private string path;
        public string DbName{ get; set; }

        public DataHelper()
        {
            DbName = typeof(T).Name+".db";
            path = Path.Combine(basePath, DbName);
            connection = new SQLiteAsyncConnection(path);
        }
        public async Task<bool> createDatabase()
        {

            try
            {
                await connection.CreateTableAsync<T>();
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public async System.Threading.Tasks.Task<int> insertUpdateDataAsync(T obj, bool contains)
        {


            if (!contains)
                return await connection.InsertAsync(obj);
            else
                return await connection.UpdateAsync(obj);
        }
        public async System.Threading.Tasks.Task<int> InsertAllAsnyc(IEnumerable<T> objects)
        {
            return await connection.InsertAllAsync(objects);
        }

        public Task<List<T>> selectItems()
        {
            using (var db = new SQLiteConnection(path))
            {
                return connection.Table<T>().ToListAsync();
            }
        }
        public async Task DeleteAll(string tableName )
        {
            using (var db = new SQLiteConnection(path))
            {
                await connection.ExecuteAsync($"DELETE FROM {tableName}");

            }
        }

        public async Task<int> Delete(T favObj)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.DeleteAsync(favObj);

            }
        }

        public async Task<T> GetById(string pk)
        {
            using (var db = new SQLiteConnection(path))
            {
                return await connection.GetAsync<T>(pk);
            }
        }
    }
}