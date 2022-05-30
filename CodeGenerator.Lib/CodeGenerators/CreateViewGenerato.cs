using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class CreateViewGenerator : CodeGenerator
    {
        public CreateViewGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectType = ProjectTypeConstant.Web;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new CreateViewTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Create.cshtml", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/Home", File = "Index.cshtml", Content = new HomeViewTemplate(namespaceName, model.Classes).TransformText() };
        }
    }
}
