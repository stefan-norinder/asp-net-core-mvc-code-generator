using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorServiceFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType);
    }

    public class CodeGeneratorServiceFactory : ICodeGeneratorServiceFactory
    {
        private readonly ICodeGenerationModelFetcherFactory generationFactory;

        public CodeGeneratorServiceFactory(ICodeGenerationModelFetcherFactory generationFactory)
        {
            this.generationFactory = generationFactory;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType)
        {
            var generationModelFetcher = generationFactory.CreateInstance(fetcherType);
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGeneratorService(generationModelFetcher);
                case CodeGeneratorTypes.Api:
                case CodeGeneratorTypes.Controllers:
                case CodeGeneratorTypes.Factories:
                case CodeGeneratorTypes.Services:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types, CodeGeneratorFetcherTypes fetcherType)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => types.HasFlag(type)))
            {
                yield return CreateInstance(type, fetcherType);
            }
            yield break;
        }
    }
}
