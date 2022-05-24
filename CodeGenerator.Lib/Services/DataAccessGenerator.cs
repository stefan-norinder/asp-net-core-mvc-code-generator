using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{
    public class DataAccessGenerator : CodeGenerator
    {
        public DataAccessGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher,
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ProjectType => ProjectTypeConstant.Logic;
        protected override string ClassTypeDescription => "DataAccess";

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            return new List<Tuple<string, string>> {
                new Tuple<string, string>("Base", new DataAccessBase(namespaceName).TransformText()),
                new Tuple<string, string>("SqlStringBuilder", new SqlStringBuilderTemplate(namespaceName).TransformText()),
                new Tuple<string, string>("Sql", new SqlDataAccessTemplate(namespaceName).TransformText()),
                new Tuple<string, string>("SqlInsertIgnoreAttribute", new SqlInsertIgnoreAttributeTemplate(namespaceName).TransformText())
            };
        }

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new DataAccessTemplate(namespaceName, @class);
                yield return template.TransformText();
            }
        }

        protected override string ProjectTemplate => new ProjectFileTemplate().TransformText();
    }
}
