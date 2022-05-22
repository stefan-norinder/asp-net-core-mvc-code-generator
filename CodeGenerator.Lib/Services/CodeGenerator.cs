using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Services
{
    public abstract class CodeGenerator : ICodeGenerator
    {
        protected readonly ICodeGenerationModelFetcher codeGeneratorFetcher;
        private readonly IOutputAdapter output;

        public CodeGenerator(ICodeGenerationModelFetcher codeGeneratorFetcher,
            IOutputAdapter output)
        {
            this.codeGeneratorFetcher = codeGeneratorFetcher;
            this.output = output;
        }

        public virtual void Invoke()
        {
            var model = codeGeneratorFetcher.Get();

            var templates = GenerateTemplatesFromModel(model);

            OutputTemplate(model.Classes, templates);
        }

        private void OutputTemplate(IEnumerable<Class> classes, IEnumerable<string> templates)
        {
            for (int i = 0; i < classes.Count(); i++)
            {
                var @class = classes.ElementAt(i);
                var file = $"{@class}{ClassTypeDescription}.cs";
                output.Write(BasePath, file, templates.ToList().ElementAt(i));
            }
        }

        protected virtual string BasePath { get { return $"./src/{ClassTypeDescription}"; } }

        protected abstract string ClassTypeDescription { get; }

        protected abstract IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model);
    }
}
