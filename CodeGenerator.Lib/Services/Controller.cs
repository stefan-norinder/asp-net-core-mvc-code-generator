using CodeGenerator.Lib.Factories;
using System.Collections;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorServiceFactory factory;
       
        public Controller(ICodeGeneratorServiceFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes = null)
        {
            foreach (var codeGenerator in factory.CreateInstances(types, fetcherTypes, namespaceName, className, propertiesAndDataTypes))
            {
                codeGenerator.Invoke();
            }
        }
    }
}
