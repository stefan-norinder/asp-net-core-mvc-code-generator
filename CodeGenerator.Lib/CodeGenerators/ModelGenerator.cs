using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ModelGenerator : CodeGenerator
    {
        public ModelGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            IOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ProjectType => ProjectTypeConstant.Logic;
        protected override string ClassTypeDescription => "Model";

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            return new List<Tuple<string, string>> { new Tuple<string, string>("Entity",new BaseEntityTemplate(namespaceName).TransformText()) };
        }

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

        protected override string ProjectTemplate => new ProjectFileTemplate().TransformText();
    }
}
