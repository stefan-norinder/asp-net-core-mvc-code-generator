using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Templates;
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
            
            GenerateProjectFileFromTemplate(model.NamespaceName);

            var staticNameAndTemplates = GenerateStaticTemplates(model.NamespaceName);

            OutputTemplate(staticNameAndTemplates);
        }

        private void GenerateProjectFileFromTemplate(string name)
        {
            var template = new ProjectFileTemplate().TransformText();
            output.Write(baseFolder,$"{name}.csproj",template);
        }

        private string baseFolder { get { return "./src/"; } }
        protected virtual string BasePath { get { return $"{baseFolder}{ClassTypeDescription}"; } }
        
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
                Output(BasePath,file, content);
            }
        }

        private void Output(string basePath,string file, string content)
        {
            output.Write(basePath, file, content);
        }

        #endregion
    }
}
