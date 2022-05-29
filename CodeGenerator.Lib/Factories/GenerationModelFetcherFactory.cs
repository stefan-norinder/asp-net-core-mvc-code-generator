using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGenerationModelFetcherFactory
    {
        ICodeGenerationModelFetcher CreateInstance(CodeGeneratorFetcherTypes type);
    }

    public class GenerationModelFetcherFactory : ICodeGenerationModelFetcherFactory
    {
        private readonly string[] args;

        public GenerationModelFetcherFactory(string[] args)
        {
            this.args = args;
        }

        //public GenerationModelFetcherFactory(string namespaceName, string className, string databaseUserId = "", string databasePassword = "")
        //{
        //    this.namespaceName = namespaceName;
        //    this.className = className;
        //    this.databaseUserId = databaseUserId;
        //    this.databasePassword = databasePassword;
        //}

        public ICodeGenerationModelFetcher CreateInstance(CodeGeneratorFetcherTypes type)
        {
            switch (type)
            {
                case CodeGeneratorFetcherTypes.FromString:
                    return new GenerationModelFetcher(args);
                case CodeGeneratorFetcherTypes.FromDatabase:
                    return new GenerationModelFromDatabaseFetcher(args);
                default:
                    throw new ArgumentException();
            }

        }
    }
}
