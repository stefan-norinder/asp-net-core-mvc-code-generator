using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class WebRootGenerator : CodeGenerator
    {
        public WebRootGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ProjectType => ProjectTypeConstant.Web;
        protected override string ClassTypeDescription => "";
        protected override string StaticFolderPath => base.ProjectFolderPath;

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            return new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Program", new ProgramTemplate(namespaceName).TransformText()),
            };
        }

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            return new List<string>
            {
                new StartupTemplate(model.Namespace, model.Classes).TransformText(),
                new AppSettingsTemplate(model.MetaData.EscapedServerString, model.MetaData.Datasource).TransformText(),
            };
        }

        protected override string ProjectTemplate => new WebProjectFileTemplate(base.namespaceName).TransformText();

        protected override void OutputTemplate(IEnumerable<Class> classes, IEnumerable<string> templates, string folderPath)
        {
            var list = templates.ToList();
            Output(ProjectFolderPath, $"Startup.cs", list[0]);
            Output(ProjectFolderPath, $"appsettings.json", list[1]);
        }
    }
}
