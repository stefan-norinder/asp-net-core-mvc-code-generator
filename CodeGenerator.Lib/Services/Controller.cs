using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<Controller> logger;

        public Controller(ICodeGeneratorFactory factory, 
            IDataAccess dataAccess, 
            ILogger<Controller> logger)
        {
            this.factory = factory;
            this.dataAccess = dataAccess;
            this.logger = logger;
        }

        public void Run(string[] args)
        {
            var generationFactory = new GenerationModelFetcherFactory(dataAccess, args);
            var generationModelFetcher = generationFactory.CreateInstance();

            foreach (var codeGenerator in factory.CreateInstances(generationModelFetcher.GeneratorTypes, generationModelFetcher))
            {
                InvokeCodeGenerator(codeGenerator);
            }
        }

        #region private 

        private void InvokeCodeGenerator(CodeGenerators.ICodeGenerator codeGenerator)
        {
            bool exceptionOccurred = default;
            try
            {
                codeGenerator.Invoke();
            }
            catch (System.Exception e)
            {
                exceptionOccurred = true;
                logger.LogError(e, e.Message);
            }
            if (exceptionOccurred) throw new System.Exception("One or more exceptions occurred during execution.");
        }

        #endregion
    }
}
