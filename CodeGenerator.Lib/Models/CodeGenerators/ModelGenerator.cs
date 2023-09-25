using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ModelGenerator : CodeGenerator
    {
        public ModelGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger, IdentifierTypeService identifierTypeService) : base(codeGenerationModelFetcher, output, logger)
        {
            this.identifierTypeService = identifierTypeService;
        }

        private string ProjectType = ProjectTypeConstant.Logic;
        private readonly IdentifierTypeService identifierTypeService;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ModelTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/Model", File = $"{@class}Model.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectTypeConstant.Logic}", File = $"{ProjectType}.csproj", Content = new ProjectFileTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/Model", File = $"Entity.cs", Content = new BaseEntityTemplate(model.Namespace, identifierTypeService.IdentifierType).TransformText() };
        }
    }
}
