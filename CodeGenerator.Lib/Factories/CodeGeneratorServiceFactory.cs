using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorServiceFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName,string className);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName, string className);
    }

    public class CodeGeneratorServiceFactory : ICodeGeneratorServiceFactory
    {
        private readonly IOutputAdapter output;

        public CodeGeneratorServiceFactory(IOutputAdapter output)
        {
            this.output = output;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type, 
            CodeGeneratorFetcherTypes fetcherType, 
            string namespaceName, 
            string className)
        {
            var generationFactory = new GenerationModelFetcherFactory(namespaceName,className);
            var generationModelFetcher = generationFactory.CreateInstance(fetcherType);
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGeneratorService(generationModelFetcher, output);
                case CodeGeneratorTypes.Api:
                case CodeGeneratorTypes.Controllers:
                case CodeGeneratorTypes.Factories:
                case CodeGeneratorTypes.Services:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types, 
            CodeGeneratorFetcherTypes fetcherType, 
            string namespaceName,
            string className)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => types.HasFlag(type)))
            {
                yield return CreateInstance(type, fetcherType, namespaceName, className);
            }
            yield break;
        }
    }
}
