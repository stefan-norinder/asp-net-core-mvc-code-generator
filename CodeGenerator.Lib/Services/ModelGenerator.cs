using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;
using System.Collections.Generic;

namespace CodeGenerator.Lib.Services
{

    public class ModelGenerator : CodeGenerator
    {
        public ModelGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ClassTypeDescription => "Model";

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            var list = new List<string>();
            foreach (var @class in model.Classes)
            {
                var template = new ModelTemplate(model.NamespaceName, @class);
                var generatedCodeFile = template.TransformText();
                list.Add(generatedCodeFile);
            }

            return list.ToArray();
        }
    }
}
