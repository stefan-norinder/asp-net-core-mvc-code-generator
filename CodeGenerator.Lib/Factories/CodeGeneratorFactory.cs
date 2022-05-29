using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type, ICodeGenerationModelFetcher generationModelFetcher);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type,  ICodeGenerationModelFetcher generationModelFetcher);
    }

    public class CodeGeneratorFactory : ICodeGeneratorFactory
    {
        private readonly IOutputAdapter output;

        public CodeGeneratorFactory(IOutputAdapter output)
        {
            this.output = output;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type,
            ICodeGenerationModelFetcher generationFetcher)
        {
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGenerator(generationFetcher, output);
                case CodeGeneratorTypes.Models:
                    return new ModelGenerator(generationFetcher, output);
                case CodeGeneratorTypes.Services:
                    return new ServiceGenerator(generationFetcher, output);
                case CodeGeneratorTypes.Api:
                    return new ApiControllerGenerator(generationFetcher, output);
                case CodeGeneratorTypes.Controllers:
                    return new ControllerGenerator(generationFetcher, output);
                case CodeGeneratorTypes.WebRoot:
                    return new WebRootGenerator(generationFetcher, output);
                case CodeGeneratorTypes.SolutionRoot:
                    return new SolutionRootGenerator(generationFetcher, output);
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types,
            ICodeGenerationModelFetcher generationModelFetcher)
        {
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => type != CodeGeneratorTypes.All && types.HasFlag(type)))
            {
                yield return CreateInstance(type, generationModelFetcher);
            }
            yield break;
        }
    }
}
