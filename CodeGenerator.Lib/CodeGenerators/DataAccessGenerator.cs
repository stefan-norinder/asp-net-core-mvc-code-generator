using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{
    public class DataAccessGenerator : CodeGenerator
    {
        public DataAccessGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        private string ProjectType => ProjectTypeConstant.Logic;
 
        protected override IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new DataAccessTemplate(model.Namespace, @class);
                yield return new TemplateModel { Folder = $"{baseFolder}{model.Namespace}.{ProjectType}/DataAccess", File = $"{@class}DataAccess.cs", Content = template.TransformText() };
            }
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}", File = $"{ProjectType}.csproj", Content = new ProjectFileTemplate().TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}/DataAccess", File = $"BaseDataAccess.cs", Content = new DataAccessBase(model.Namespace).TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}/DataAccess", File = $"SqlStringBuilderDataAccess.cs", Content = new SqlStringBuilderTemplate(model.Namespace).TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}/DataAccess", File = $"SqlDataAccess.cs", Content = new SqlDataAccessTemplate(model.Namespace).TransformText() };
            yield return new TemplateModel { Folder = $"{baseFolder}{namespaceName}.{ProjectType}/DataAccess", File = $"SqlInsertIgnoreAttributeDataAccess.cs", Content = new SqlInsertIgnoreAttributeTemplate(model.Namespace).TransformText() };
        }
    }
}
