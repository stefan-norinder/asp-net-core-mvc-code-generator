using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{
    public abstract class CodeGenerator : ICodeGenerator
    {
        protected readonly ICodeGenerationModelFetcher codeGeneratorFetcher;
        protected readonly IOutputAdapter output;
        protected string namespaceName;

        public CodeGenerator(ICodeGenerationModelFetcher codeGeneratorFetcher,
            IOutputAdapter output)
        {
            this.codeGeneratorFetcher = codeGeneratorFetcher;
            this.output = output;
        }

        public virtual void Invoke()
        {
            var model = codeGeneratorFetcher.Get();

            namespaceName = model.Namespace;

            var templates = GenerateTemplatesFromModel(model);

            foreach (var template in templates)
            {
                output.Write(template.Folder, template.File, template.Content);
            }
        }

        protected string baseFolder { get { return "./src/"; } }

        protected abstract IEnumerable<TemplateModel> GenerateTemplatesFromModel(CodeGenerationModel model);

        #region private

        #endregion

        protected static class ProjectTypeConstant
        {
            public static string Logic = "Logic";
            public static string Web = "Web";
            public static string Solution = "Solution";
            public static string Test = "Test";

        }
        protected class TemplateModel
        {
            public string Content { get; set; }
            public string Folder { get; set; }
            public string File{ get; set; }
        }

        }
}
