using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeGeneratorExample.Logic.DataAccess
{
    public interface IDataAccess<T>
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task Insert(T model);
        Task Update(T model);
        Task Delete(int id);
        Task DeleteAll();
    }

    public class DataAccessBase<T> : IDataAccess<T>
    {
        protected readonly ISqlDataAccess db;
        private readonly SqlStringBuilder<T> sqlStringBuilder;

        public DataAccessBase(ISqlDataAccess db,
            SqlStringBuilder<T> sqlStringBuilder)
        {
            this.db = db;
            this.sqlStringBuilder = sqlStringBuilder;
            Table = typeof(T).Name;
        }

        protected string Table { get; }

        public async virtual Task Insert(T model)
        {
            string sql = sqlStringBuilder.GetInsertString(model);

            await db.SaveData(sql, model);
        }

        public async virtual Task Update(T model)
        {
            string sql = sqlStringBuilder.GetUpdateString(model);

            await db.SaveData(sql, model);
        }

        public virtual async Task<List<T>> GetAll()
        {
            string sql = $"SELECT * FROM {Table} ";
            return await ExecuteSelectMany(sql);
        }
        
        public virtual async Task<T> Get(int id)
        {
            string sql = $"SELECT * FROM {Table} Where Id = @id";
            return await db.LoadSingularData<T, dynamic>(sql, new { Id = id });
        }

        public async Task DeleteAll()
        {
            string sql = $"DELETE FROM {Table} ";
            await db.SaveData(sql, new { });
        }

        public async Task Delete(int id)
        {
            string sql = $"DELETE FROM {Table} WHERE Id = @id";
            await db.SaveData(sql, new { Id = id });
        }

        protected async Task<T> ExecuteSelectSingle(string sql, int id)
        {
            return await db.LoadSingularData<T, dynamic>(sql, new { Id = id });
        }

        protected async Task<T> ExecuteSelectSingle(string sql)
        {
            return await db.LoadSingularData<T, dynamic>(sql, new { });
        }

        protected async Task<List<T>> ExecuteSelectMany(string sql)
        {
            return await db.LoadData<T, dynamic>(sql, new { });
        }
    }
}
