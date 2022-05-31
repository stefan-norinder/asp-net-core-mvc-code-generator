using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ViewsGenerator : CodeGenerator
    {
        public ViewsGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectType = ProjectTypeConstant.Web;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Index.cshtml", Content = new ListViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Create.cshtml", Content = new CreateViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Edit.cshtml", Content = new EditViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Remove.cshtml", Content = new DeleteViewTemplate(model.Namespace, @class).TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/Home", File = "Index.cshtml", Content = new HomeViewTemplate(namespaceName, model.Classes).TransformText() };
        }
    }
}
