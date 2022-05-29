using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{
    public interface IController
    {
        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, string @namespace, IEnumerable<ParamClass> classes);
        void Run(CodeGeneratorTypes alltypes, CodeGeneratorFetcherTypes fetcherTypes, ParamsModel paramsModel);
    }

    public class Controller : IController
    {
        private readonly ICodeGeneratorFactory factory;

        public Controller(ICodeGeneratorFactory factory)
        {
            this.factory = factory;
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherType, string @namespace, IEnumerable<ParamClass> classes)
        {

            var generationFactory = new GenerationModelFetcherFactory(@namespace, classes);
            var generationModelFetcher = generationFactory.CreateInstance(fetcherType);

            foreach (var codeGenerator in factory.CreateInstances(types, fetcherType, @namespace, classes, generationModelFetcher))
            {
                codeGenerator.Invoke();
            }
        }

        public void Run(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherTypes, ParamsModel paramsModel)
        {
            Run(types, fetcherTypes, paramsModel.Namespace, paramsModel.Classes);
        }
    }
}
