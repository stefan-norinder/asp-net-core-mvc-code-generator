using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;
using System;

namespace CodeGenerator.Lib.Services
{

    public class DataAccessGeneratorService : CodeGenerator
    {
        public DataAccessGeneratorService(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        public override string[] GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            var template = new DataAccessTemplate(model);
            return new [] { template.TransformText() };
        }
    }
}
