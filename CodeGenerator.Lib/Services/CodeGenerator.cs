using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using System;
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

            var staticNameAndTemplates = GenerateStaticTemplates(model.NamespaceName);

            OutputTemplate(staticNameAndTemplates);
        }

        protected virtual string BasePath { get { return $"./src/{ClassTypeDescription}"; } }

        protected abstract string ClassTypeDescription { get; }

        protected abstract IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model);

        protected abstract IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName);

        #region private

        private void OutputTemplate(IEnumerable<Class> classes, IEnumerable<string> templates)
        {
            OutputTemplate(classes.Select(x => x.ToString()), templates);
        }

        private void OutputTemplate(IEnumerable<Tuple<string, string>> nameAndTemplatesList)
        {
            var names = nameAndTemplatesList.Select(x => x.Item1);
            var templates = nameAndTemplatesList.Select(x => x.Item2);
            OutputTemplate(names, templates);
        }

        private void OutputTemplate(IEnumerable<string> classes, IEnumerable<string> templates)
        {
            for (int i = 0; i < templates.Count(); i++)
            {
                var @class = classes.ElementAt(i);
                var file = $"{@class}{ClassTypeDescription}.cs";
                var content = templates.ToList().ElementAt(i);
                Output(file, content);
            }
        }

        private void Output(string file, string content)
        {
            output.Write(BasePath, file, content);
        }

        #endregion
    }
}
