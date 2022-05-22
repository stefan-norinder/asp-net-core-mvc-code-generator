using CodeGeneratorExample.Logic.DataAccess;
using CodeGeneratorExample.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeGeneratorExample.Services
{
    public interface IService<TModel>
    {
        Task<TModel> Get(int id);
        Task<IEnumerable<TModel>> GetAll();
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Delete(int id);
    }

    public class Service<TModel> : IService<TModel> where TModel : Entity
    {
        protected readonly ILogger<Service<TModel>> logger;
        protected readonly IDataAccess<TModel> dataAccess;

        public Service(ILogger<Service<TModel>> logger,
            IDataAccess<TModel> dataAccess)
        {
            this.logger = logger;
            this.dataAccess = dataAccess;
        }

        public async Task<TModel> Get(int id)
        {
            return await dataAccess.Get(id);
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await dataAccess.GetAll();
        }

        public async virtual Task Insert(TModel model)
        {
            await dataAccess.Insert(model);
        }

        public async virtual Task Update(TModel model)
        {
            await dataAccess.Update(model);
        }

        public async Task Delete(int id)
        {
            await dataAccess.Delete(id);
        }
    }
}
