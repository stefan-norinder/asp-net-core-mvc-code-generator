using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Utils;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string[] args);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorFactory factory;

        public Controller(ICodeGeneratorFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherType, string[] args)
        {

            var generationFactory = new GenerationModelFetcherFactory(args);
            var generationModelFetcher = generationFactory.CreateInstance(fetcherType);

            foreach (var codeGenerator in factory.CreateInstances(types, fetcherType, generationModelFetcher))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
