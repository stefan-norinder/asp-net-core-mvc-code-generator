using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes);
    }

    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly IOutputAdapter output;

        public CodeGeneratorFactory(IOutputAdapter output)
        {
            this.output = output;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type,
            CodeGeneratorFetcherTypes fetcherType,
            string namespaceName,
            string className, 
            IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes=null)
        {
            var generationFactory = new GenerationModelFetcherFactory(namespaceName, className, propertiesAndDataTypes);
            var generationModelFetcher = generationFactory.CreateInstance(fetcherType);
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.Models:
                    return new ModelGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.Services:
                    return new ServiceGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.Api:
                case CodeGeneratorTypes.Controllers:
                case CodeGeneratorTypes.Factories:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types,
            CodeGeneratorFetcherTypes fetcherType,
            string namespaceName,
            string className,
            IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes = null)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => types.HasFlag(type)))
            {
                yield return CreateInstance(type, fetcherType, namespaceName, className, propertiesAndDataTypes);
            }
            yield break;
        }
    }
}
