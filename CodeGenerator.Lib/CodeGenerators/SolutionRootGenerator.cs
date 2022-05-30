using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class SolutionRootGenerator : CodeGenerator
    {
        public SolutionRootGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            yield return new TemplateModel { Folder = baseFolder, File = $"App.sln", Content = new SolutionTempate(base.namespaceName).TransformText() };
        }
    }
}
