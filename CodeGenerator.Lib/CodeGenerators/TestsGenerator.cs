using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class TestsGenerator : CodeGenerator
    {
        public TestsGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectType = ProjectTypeConstant.Test;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var serviceTestTemplate = new ServiceTestTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/ServiceTests", File = $"{@class}ServiceTests.cs", Content = serviceTestTemplate.TransformText() };
                var modelTestsTemplate = new ModelTestsTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/ModelTests", File = $"{@class}ModelTests.cs", Content = modelTestsTemplate.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectTypeConstant.Test}", File = $"{ProjectTypeConstant.Test}.csproj", Content = new TestProjectTemplate(model.Namespace).TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectTypeConstant.Test}", File = "TestUtils.cs", Content = new TestUtilsTemplate(model.Namespace).TransformText() };
        }

    }
}
