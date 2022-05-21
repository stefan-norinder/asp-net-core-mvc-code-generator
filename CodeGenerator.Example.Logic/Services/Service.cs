using CodeGeneratorExample.Logic.DataAccess;
using CodeGeneratorExample.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CodeGeneratorExample.Services
{
    public interface IService<TModel>
    {
        Task<TModel> Get(int id);
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

    }
}
