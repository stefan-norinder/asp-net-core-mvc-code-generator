using CodeGenerator.Lib.Factories;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string namespaceName, string className);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorServiceFactory factory;
       
        public Controller(ICodeGeneratorServiceFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string namespaceName, string className)
        {
            foreach (var codeGenerator in factory.CreateInstances(types, fetcherTypes, namespaceName, className))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
