using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ControllerGenerator : CodeGenerator
    {
        public ControllerGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ControllerTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}{ProjectTypeConstant.Web}.Controller", File = $"{@class}Controller.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectTypeConstant.Logic}", File = $"{ProjectTypeConstant.Web}.csproj", Content = new ProjectFileTemplate().TransformText() };
        }
    }
}
