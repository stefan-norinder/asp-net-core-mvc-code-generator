using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Utils;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        public void Run(string[] args);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorFactory factory;
        private readonly IDataAccess dataAccess;

        public Controller(ICodeGeneratorFactory factory, 
            IDataAccess dataAccess)
        {
            this.factory = factory;
            this.dataAccess = dataAccess;
        }

        public void Run(string[] args)
        {
            var generationFactory = new GenerationModelFetcherFactory(dataAccess, args);
            var generationModelFetcher = generationFactory.CreateInstance();          

            foreach (var codeGenerator in factory.CreateInstances(generationModelFetcher.GeneratorTypes, generationModelFetcher))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
