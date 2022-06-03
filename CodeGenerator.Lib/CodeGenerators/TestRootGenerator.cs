using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{
    public class TestRootGenerator : CodeGenerator
    {
        public TestRootGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectFolderPath => $"{baseFolder}{namespaceName}";

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            yield return new TemplateModel { Folder = $"{ProjectFolderPath}.{ProjectTypeConstant.Test}", File = $"{ProjectTypeConstant.Test}.csproj", Content = new TestProjectTemplate(model.Namespace).TransformText() };
        }
    }
}
