using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Utils;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        public void Run(CodeGeneratorTypes types, string[] args);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorFactory factory;

        public Controller(ICodeGeneratorFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, string[] args)
        {
            var generationFactory = new GenerationModelFetcherFactory(args);
            var generationModelFetcher = generationFactory.CreateInstance();

            foreach (var codeGenerator in factory.CreateInstances(types, generationModelFetcher))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
