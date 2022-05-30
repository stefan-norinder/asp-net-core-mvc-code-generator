using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Services
{

    public class ApiControllerGenerator : CodeGenerators.CodeGenerator
    {
        public ApiControllerGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ApiControllerTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{FolderPath}.{ProjectTypeConstant.Logic}.ApiController", File = $"{@class}ApiController.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectTypeConstant.Logic}", File = $"{ProjectTypeConstant.Logic}.csproj", Content = new ProjectFileTemplate().TransformText() };
        }
    }
}
