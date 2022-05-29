using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName, IEnumerable<ParamClass> classes);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type, CodeGeneratorFetcherTypes fetcherType, string namespaceName, IEnumerable<ParamClass> classes);
    }

    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly FileWriterOutputAdapter output;

        public CodeGeneratorFactory(FileWriterOutputAdapter output)
        {
            this.output = output;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type,
            CodeGeneratorFetcherTypes fetcherType,
            string namespaceName,
            IEnumerable<ParamClass> classes)
        {
            var generationFactory = new GenerationModelFetcherFactory(namespaceName, classes);
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
                    return new ApiControllerGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.Controllers:
                    return new ControllerGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.WebRoot:
                    return new WebRootGenerator(generationModelFetcher, output);
                case CodeGeneratorTypes.SolutionRoot:
                    return new SolutionRootGenerator(generationModelFetcher, output);
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types,
            CodeGeneratorFetcherTypes fetcherType,
            string namespaceName,
            IEnumerable<ParamClass> classes)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => type != CodeGeneratorTypes.All && types.HasFlag(type)))
            {
                yield return CreateInstance(type, fetcherType, namespaceName, classes);
            }
            yield break;
        }
    }
}
