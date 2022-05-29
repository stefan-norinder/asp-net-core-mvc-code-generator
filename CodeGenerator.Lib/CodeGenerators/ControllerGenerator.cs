using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.CodeGenerators
{

    public class ControllerGenerator : CodeGenerator
    {
        public ControllerGenerator(ICodeGenerationModelFetcher codeGenerationModelFetcher, 
            FileWriterOutputAdapter output) : base(codeGenerationModelFetcher, output)
        { }

        protected override string ProjectType => ProjectTypeConstant.Web;
        protected override string ClassTypeDescription => "Controller";

        protected override IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName)
        {
            return Enumerable.Empty<Tuple<string, string>>();
        }

        protected override IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model)
        {
            var list = new List<string>();
            foreach (var @class in model.Classes)
            {
                var template = new ControllerTemplate(model.NamespaceName, @class);
                var generatedCodeFile = template.TransformText();
                list.Add(generatedCodeFile);
            }

            return list.ToArray();
        }
        protected override string ProjectTemplate => new WebProjectFileTemplate(namespaceName).TransformText();
    }
}
