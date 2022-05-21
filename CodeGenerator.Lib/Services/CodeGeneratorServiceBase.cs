using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;

namespace CodeGenerator.Lib.Services
{
    public abstract class CodeGeneratorServiceBase : ICodeGenerator
    {
        protected readonly ICodeGenerationModelFetcher codeGeneratorFetcher;

        public CodeGeneratorServiceBase(ICodeGenerationModelFetcher codeGeneratorFetcher)
        {
            this.codeGeneratorFetcher = codeGeneratorFetcher;
        }

        public virtual void Invoke()
        {
            //fetch data 
            var model = codeGeneratorFetcher.Get();

            //process data 
            var template = new DataAccessTemplate(codeGeneratorFetcher.Namespace, model).TransformText();

            //save data to disk
        }

        public abstract void Process();
    }
}
