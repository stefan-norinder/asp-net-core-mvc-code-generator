using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ViewModelGenerator : CodeGenerator
    {
        public ViewModelGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger) : base(codeGenerationModelFetcher, output, logger)
        { }

        private string ProjectType = ProjectTypeConstant.Web;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ViewModelTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/ViewModel", File = $"{@class}ViewModel.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}", File = $"{ProjectType}.csproj", Content = new WebProjectFileTemplate(namespaceName).TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}/ViewModel", File = $"ViewModelBase.cs", Content = new ViewModelBaseTemplate(namespaceName).TransformText() };
        }
    }
}
