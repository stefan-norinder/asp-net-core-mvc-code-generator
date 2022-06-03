using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System.Collections.Generic;
using System;
using System.IO;

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
            GenerateContentForWwwRoot(model);
            GenerateStaticSharedContent(model);

            foreach (var @class in model.Classes)
            {
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Index.cshtml", Content = new ListViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Create.cshtml", Content = new CreateViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Edit.cshtml", Content = new EditViewTemplate(model.Namespace, @class).TransformText() };
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/{@class.Name}", File = "Remove.cshtml", Content = new DeleteViewTemplate(model.Namespace, @class).TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/Home", File = "Index.cshtml", Content = new HomeViewTemplate(namespaceName, model.Classes).TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/Shared", File = "_Layout.cshtml", Content = new LayoutViewTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views", File = "_ViewImports.cshtml", Content = new ImportsViewTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Views", File = "_ViewStart.cshtml", Content = new StartViewTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Resources", File = "SharedResource.en.resx", Content = new ResourceTemplate(namespaceName, model.Classes).TransformText() };
        }

        private void GenerateStaticSharedContent(CodeGenerationModel model)
        {
            var source = "./Templates/StaticContent/StaticSharedContent";
            var target = $"{baseFolder}{model.Namespace}.{ProjectType}/Views/Shared";
            output.CopyFoldersAndFilesFromSourceToTarge(source, target);
        }

        private void GenerateContentForWwwRoot(CodeGenerationModel model)
        {
            var source = "./Templates/StaticContent/wwwroot";
            var target = $"{baseFolder}{model.Namespace}.{ProjectType}/wwwroot";
            output.CopyFoldersAndFilesFromSourceToTarge(source, target);
        }
    }
}
