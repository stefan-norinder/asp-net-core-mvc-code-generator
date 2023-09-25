using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class TestsGenerator : CodeGenerator
    {
        public TestsGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger, IdentifierTypeService identifierTypeService) : base(codeGenerationModelFetcher, output, logger)
        {
            this.identifierTypeService = identifierTypeService;
        }

        private string ProjectType = ProjectTypeConstant.Test;
        private readonly IdentifierTypeService identifierTypeService;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var serviceTestTemplate = new ServiceTestTemplate(model.Namespace, @class, identifierTypeService.IdentifierType);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/ServiceTests", File = $"{@class}ServiceTests.cs", Content = serviceTestTemplate.TransformText() };
                var modelTestsTemplate = new ModelTestsTemplate(model.Namespace, @class, identifierTypeService.IdentifierType);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/ModelTests", File = $"{@class}ModelTests.cs", Content = modelTestsTemplate.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectTypeConstant.Test}", File = $"{ProjectTypeConstant.Test}.csproj", Content = new TestProjectTemplate(model.Namespace).TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectTypeConstant.Test}", File = "TestUtils.cs", Content = new TestUtilsTemplate(model.Namespace).TransformText() };
        }

    }
}
