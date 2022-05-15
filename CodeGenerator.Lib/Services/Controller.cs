using CodeGenerator.Lib.Factories;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes types);    
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorServiceFactory factory;

        public Controller(string server, string database, string userId = "", string password = "")
        {
            factory = new CodeGeneratorServiceFactory(server, database, userId, password);
        }

        public Controller(ICodeGeneratorServiceFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types)
        {
            foreach (var codeGenerator in factory.CreateInstances(types))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
