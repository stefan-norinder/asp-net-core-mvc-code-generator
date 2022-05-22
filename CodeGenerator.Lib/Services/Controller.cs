using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes);
        void Run(CodeGeneratorTypes alltypes, CodeGeneratorFetcherTypes fetcherTypes, ParamsModel paramsModel);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorFactory factory;
       
        public Controller(ICodeGeneratorFactory factory)
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

        public void Run(CodeGeneratorTypes alltypes, CodeGeneratorFetcherTypes fetcherTypes, ParamsModel paramsModel)
        {
            foreach (var @class in paramsModel.Classes)
            {
                Run(CodeGeneratorTypes.All, fetcherTypes, paramsModel.Namespace, @class.ClassName, @class.Properties);
            }
        }
    }
}
