using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Services;
using System;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGenerationModelFetcherFactory
    {
        ICodeGenerationModelFetcher CreateInstance(CodeGeneratorFetcherTypes type);
    }

    public class GenerationModelFetcherFactory : ICodeGenerationModelFetcherFactory
    {
        private readonly string namespaceName;
        private readonly string className;
        private readonly string databaseUserId;
        private readonly string databasePassword;

        public GenerationModelFetcherFactory(string namespaceName, string className, string databaseUserId = "", string databasePassword = "")
        {
            this.namespaceName = namespaceName;
            this.className = className;
            this.databaseUserId = databaseUserId;
            this.databasePassword = databasePassword;
        }

        public ICodeGenerationModelFetcher CreateInstance(CodeGeneratorFetcherTypes type)
        {
            switch (type)
            {
                case CodeGeneratorFetcherTypes.FromString:
                    return new GenerationModelFetcher(namespaceName, className);
                case CodeGeneratorFetcherTypes.FromDatabase:
                    return new GenerationModelFromDatabaseFetcher(namespaceName, className,databaseUserId, databasePassword);
                default:
                    throw new ArgumentException();
            }

        }
    }
}
