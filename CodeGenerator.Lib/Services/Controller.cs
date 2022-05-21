using CodeGenerator.Lib.Factories;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorServiceFactory factory;

       
        public Controller(ICodeGeneratorServiceFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes)
        {
            foreach (var codeGenerator in factory.CreateInstances(types, fetcherTypes))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
