using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.CodeGenerators
{
    public abstract class CodeGenerator : ICodeGenerator
    {
        protected readonly ICodeGenerationModelFetcher codeGeneratorFetcher;
        private readonly IOutputAdapter output;
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

            namespaceName = model.NamespaceName;

            var templates = GenerateTemplatesFromModel(model);

            OutputTemplate(model.Classes, templates, FolderPath);

            GenerateProjectFileFromTemplate();

            var staticNameAndTemplates = GenerateStaticTemplates(namespaceName);

            OutputTemplate(staticNameAndTemplates, StaticFolderPath);
        }

        protected virtual void GenerateProjectFileFromTemplate()
        {
            output.Write(ProjectFolderPath, $"{ProjectType}.csproj", ProjectTemplate);
        }

        protected abstract string ProjectTemplate { get; }

        protected string baseFolder { get { return "./src/"; } }

        protected virtual string ProjectFolderPath => $"{baseFolder}{namespaceName}.{ProjectType}";
        protected virtual string FolderPath => $"{ProjectFolderPath}/{namespaceName}.{ProjectType}.{ClassTypeDescription}";
        protected virtual string StaticFolderPath => $"{ProjectFolderPath}/{namespaceName}.{ProjectType}.{ClassTypeDescription}";

        protected abstract string ProjectType { get; }

        protected abstract string ClassTypeDescription { get; }

        protected abstract IEnumerable<string> GenerateTemplatesFromModel(CodeGenerationModel model);

        protected abstract IEnumerable<Tuple<string, string>> GenerateStaticTemplates(string namespaceName);

        #region private

        protected virtual void OutputTemplate(IEnumerable<Class> classes, IEnumerable<string> templates, string folderPath)
        {
            OutputTemplate(classes.Select(x => x.ToString()), templates, folderPath);
        }

        private void OutputTemplate(IEnumerable<Tuple<string, string>> nameAndTemplatesList, string folderPath)
        {
            var names = nameAndTemplatesList.Select(x => x.Item1);
            var templates = nameAndTemplatesList.Select(x => x.Item2);
            OutputTemplate(names, templates, folderPath);
        }

        protected virtual void OutputTemplate(IEnumerable<string> classes, IEnumerable<string> templates, string folderPath)
        {
            for (int i = 0; i < templates.Count(); i++)
            {
                var @class = classes.ElementAt(i);
                var file = $"{@class}{ClassTypeDescription}.cs";
                var content = templates.ToList().ElementAt(i);
                Output(folderPath, file, content);
            }
        }

        protected void Output(string basePath, string file, string content)
        {
            output.Write(basePath, file, content);
        }

        #endregion

        protected static class ProjectTypeConstant
        {
            public static string Logic = "Lib";
            public static string Web = "Web";
            public static string Solution = "Solution";
        }
    }
}
