using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ApiControllerGenerator : CodeGenerator
    {
        public ApiControllerGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ApiControllerTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectTypeConstant.Web}/ApiController", File = $"{@class}ApiController.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectTypeConstant.Web}", File = $"{ProjectTypeConstant.Web}.csproj", Content = new WebProjectFileTemplate(namespaceName).TransformText() };
        }
    }
}
