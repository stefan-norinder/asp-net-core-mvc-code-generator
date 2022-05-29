using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class SolutionRootGenerator : CodeGenerator
    {
        public SolutionRootGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ProjectType => ProjectTypeConstant.Solution;
        protected override string ClassTypeDescription => "App";
        protected override string StaticFolderPath => baseFolder;

        protected override string ProjectTemplate => throw new NotImplementedException();

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            return new List<Tuple<string, string>>
            {
                new Tuple<string, string>(string.Empty, new SolutionTempate(base.namespaceName).TransformText()),
            };
        }

        protected override void OutputTemplate(IEnumerable<string> classes, IEnumerable<string> templates, string folderPath)
        {
            if (!templates.Any()) return;
            var file = $"{ClassTypeDescription}.sln";
            Output(folderPath, file, templates.First());
        }

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            return Enumerable.Empty<string>();
        }

        protected override void GenerateProjectFileFromTemplate()
        {
            // do nothing
        }
    }
}
