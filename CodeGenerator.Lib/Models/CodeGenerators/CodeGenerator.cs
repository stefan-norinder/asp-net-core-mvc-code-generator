﻿using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CodeGenerator.Lib.CodeGenerators
{
    public abstract class CodeGenerator : ICodeGenerator
    {
        protected readonly ICodeGenerationModelFetcher codeGeneratorFetcher;
        protected readonly IOutputAdapter output;
        private readonly ILogger<CodeGenerator> logger;
        protected string namespaceName;

        public CodeGenerator(ICodeGenerationModelFetcher codeGeneratorFetcher,
            IOutputAdapter output,  ILogger<CodeGenerator> logger)
        {
            this.codeGeneratorFetcher = codeGeneratorFetcher;
            this.output = output;
            this.logger = logger;
        }

        public virtual void Invoke()
        {
            var model = codeGeneratorFetcher.Get();
            namespaceName = model.Namespace;

            BaseFolder = model.MetaData.Output;

            var templates = GenerateTemplatesFromModel(model);

            foreach (var template in templates)
            {
                namespaceName = model.Namespace;

                output.Write(template.Folder, template.File, template.Content);
                logger.LogInformation($"output: {template.Folder}/{template.File}");
            }
        }

        private string baseFolder;
        protected string BaseFolder { get { return string.IsNullOrEmpty(baseFolder) || baseFolder == "/" ? "./src/" : baseFolder; } set { baseFolder = value;  } }

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
