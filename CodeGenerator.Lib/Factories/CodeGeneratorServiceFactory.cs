using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorServiceFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type);
    }

    public class CodeGeneratorServiceFactory : ICodeGeneratorServiceFactory
    {
        private readonly ICodeGenerationModelFetcher generationModelFetcher;

        public CodeGeneratorServiceFactory(string className)
        {
            generationModelFetcher = new GenerationModelFetcher(className);
        }

        public CodeGeneratorServiceFactory(string server, string database, string userId = "", string password = "")
        {
            generationModelFetcher = new GenerationModelFromDatabase(server, database, userId, password);
        }

        public CodeGeneratorServiceFactory(ICodeGenerationModelFetcher dataAccess)
        {
            this.generationModelFetcher = dataAccess;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type)
        {
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGeneratorService(CodeGeneratorTypes.DataAccess, generationModelFetcher);
                case CodeGeneratorTypes.Api:
                case CodeGeneratorTypes.Controllers:
                case CodeGeneratorTypes.Factories:
                case CodeGeneratorTypes.Services:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => types.HasFlag(type)))
            {
                yield return CreateInstance(type);
            }
            yield break;
        }
    }
}
