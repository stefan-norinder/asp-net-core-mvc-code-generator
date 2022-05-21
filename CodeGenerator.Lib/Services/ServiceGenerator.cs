using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{

    public class ServiceGenerator : CodeGenerator
    {
        public ServiceGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        public override string[] GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            var list = new List<string>();
            foreach (var @class in model.Classes)
            {
                var template = new ServiceTemplate(model.NamespaceName, @class);
                var generatedCodeFile = template.TransformText();
                list.Add(generatedCodeFile);
            }

            return list.ToArray();
        }
    }
}
