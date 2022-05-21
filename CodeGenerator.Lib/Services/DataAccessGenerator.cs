using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;
using System;
using System.Linq;

namespace CodeGenerator.Lib.Services
{

    public class DataAccessGenerator : CodeGenerator
    {
        public DataAccessGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        public override string[] GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            var template = new DataAccessTemplate(model.NamespaceName, model.Classes.First());
            return new [] { template.TransformText() };
        }
    }
}
