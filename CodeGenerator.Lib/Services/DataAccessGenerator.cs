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

        protected override string ClassTypeDescription => "DataAccess";

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            var name = "Base";
            var template = new DataAccessBase(namespaceName).TransformText();
            return new List<Tuple<string, string>> { new Tuple<string, string>(name, template) };
        }

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            foreach (var @class in model.Classes)
            {
                var template = new DataAccessTemplate(model.NamespaceName, @class);
                yield return template.TransformText();
            }
        }
    }
}
