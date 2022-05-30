using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ServiceGenerator : CodeGenerator
    {
        public ServiceGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectType = ProjectTypeConstant.Logic;

        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new ServiceTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/Service", File = $"{@class}Service.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}", File = $"{ProjectType}.csproj", Content = new ProjectFileTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}/Service", File = $"Service.cs", Content = new BaseServiceTemplate(namespaceName).TransformText() };
        }

    }
}
