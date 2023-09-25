using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CodeGenerators.CodeGenerator> logger;
        private readonly IdentifierTypeService identifierTypeService;

        public CodeGeneratorFactory(IOutputAdapter output, ILogger<CodeGenerators.CodeGenerator> logger, IdentifierTypeService identifierTypeService)
        {
            this.output = output;
            this.logger = logger;
            this.identifierTypeService = identifierTypeService;
        }

        public ICodeGenerator CreateInstance(CodeGeneratorTypes type,
            ICodeGenerationModelFetcher generationFetcher)
        {
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.Model:
                    return new ModelGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.Service:
                    return new ServiceGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.Api:
                    return new ApiControllerGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.Controllers:
                    return new ControllerGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.WebRoot:
                    return new WebRootGenerator(generationFetcher, output, logger);
                case CodeGeneratorTypes.SolutionRoot:
                    return new SolutionRootGenerator(generationFetcher, output, logger);
                case CodeGeneratorTypes.ViewModels:
                    return new ViewModelGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.Views:
                    return new ViewsGenerator(generationFetcher, output, logger);
                case CodeGeneratorTypes.Test:
                    return new TestsGenerator(generationFetcher, output, logger, identifierTypeService);
                case CodeGeneratorTypes.HttpService:
                    return new HttpServiceGenerator(generationFetcher, output, logger);
                case CodeGeneratorTypes.None:
                    return null;
                default:
                    throw new ArgumentException(type.ToString());
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types,
            ICodeGenerationModelFetcher generationModelFetcher)
        {
            if (types == CodeGeneratorTypes.None) types = CodeGeneratorTypes.All;
            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>();
            foreach (var type in allCodeGeneratorTypes.Where(type => type != CodeGeneratorTypes.All && type != CodeGeneratorTypes.None && types.HasFlag(type)))
            {
                yield return CreateInstance(type, generationModelFetcher);
            }
            yield break;
        }
    }
}
