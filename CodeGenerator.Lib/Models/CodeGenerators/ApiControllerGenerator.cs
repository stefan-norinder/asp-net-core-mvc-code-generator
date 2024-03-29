﻿using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ApiControllerGenerator : CodeGenerator
    {
        private readonly IdentifierTypeService identifierTypeService;

        public ApiControllerGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger, IdentifierTypeService identifierTypeService) : base(codeGenerationModelFetcher, output, logger)
        {
            this.identifierTypeService = identifierTypeService;
        }

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ApiControllerTemplate(model.Namespace, @class, identifierTypeService.IdentifierType);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectTypeConstant.Web}/ApiController", File = $"{@class}ApiController.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectTypeConstant.Web}", File = $"{ProjectTypeConstant.Web}.csproj", Content = new WebProjectFileTemplate(namespaceName).TransformText() };
        }
    }
}
