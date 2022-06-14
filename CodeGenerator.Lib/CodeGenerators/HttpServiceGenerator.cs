using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class HttpServiceGenerator : CodeGenerator
    {
        public HttpServiceGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger) : base(codeGenerationModelFetcher, output, logger)
        { }

        private string ProjectType = ProjectTypeConstant.Logic;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new HttpServiceTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{BaseFolder}{model.Namespace}.{ProjectType}/Http", File = $"{@class}HttpService.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}", File = $"{ProjectType}.csproj", Content = new ProjectFileTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}/Http", File = $"HttpClient.cs", Content = new HttpClientTemplate(namespaceName).TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}/Http", File = $"HttpService.cs", Content = new HttpServiceBaseTemplate(namespaceName).TransformText() };
            yield return new TemplateModel { Folder = $"{BaseFolder}{namespaceName}.{ProjectType}/Setting", File = $"AuthenticationSettings.cs", Content = new AuthenticationSettingsTemplate(namespaceName).TransformText() };
        }

    }
}
