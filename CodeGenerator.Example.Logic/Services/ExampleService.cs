using CodeGeneratorExample.Logic.DataAccess;
using CodeGeneratorExample.Models;
using Microsoft.Extensions.Logging;

namespace CodeGeneratorExample.Services
{
    public interface IExampleService : IService<Example>
    {
    }

    public class ExampleService : Service<Example>, IExampleService
    {
        public ExampleService(ILogger<ExampleService> logger,
           IExampleDataAccess dataAccess)
           : base(logger, dataAccess)
        { }
    }
}
