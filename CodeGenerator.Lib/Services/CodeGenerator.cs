using CodeGenerator.Lib.DataAccess;

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

            output.Write(templates);
        }

        public abstract string[] GenerateTemplatesFromModel(CodeGenerationModel model);
    }
}
