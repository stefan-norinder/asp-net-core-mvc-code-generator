using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class WebRootGenerator : CodeGenerator
    {
        public WebRootGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectFolderPath => $"{baseFolder}{namespaceName}";

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            GenerateStaticContent($"{baseFolder}{model.Namespace}.{ProjectTypeConstant.Web}");

            return new List<TemplateModel>
            {
                new TemplateModel { Folder = $"{ProjectFolderPath}.{ProjectTypeConstant.Web}", File = "Startup.cs", Content =  new StartupTemplate(model.Namespace, model.Classes).TransformText()},
                new TemplateModel { Folder = $"{ProjectFolderPath}.{ProjectTypeConstant.Web}", File = "Program.cs", Content =  new ProgramTemplate(model.Namespace).TransformText()},
                new TemplateModel { Folder = $"{ProjectFolderPath}.{ProjectTypeConstant.Web}", File = "appsettings.json", Content =  new AppSettingsTemplate(model.MetaData.EscapedServerString, model.MetaData.Datasource).TransformText()},
                new TemplateModel { Folder = $"{ProjectFolderPath}.{ProjectTypeConstant.Web}", File = $"{ProjectTypeConstant.Web}.csproj", Content =  new WebProjectFileTemplate(model.Namespace).TransformText()},
            };
        }
        private void GenerateStaticContent(string basePath)
        {
            var sourcePath = "./Templates/StaticContent/WebProjectRoot";
            var targetPath = $"{basePath}";

            output.CopyFoldersAndFilesFromSourceToTarge(sourcePath, targetPath);
        }
    }
}
