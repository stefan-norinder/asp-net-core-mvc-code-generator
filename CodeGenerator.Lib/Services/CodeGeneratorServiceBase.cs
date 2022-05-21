using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Templates;

namespace CodeGenerator.Lib.Services
{
    public abstract class CodeGeneratorServiceBase : ICodeGenerator
    {
        private readonly CodeGeneratorTypes type;
        protected readonly ICodeGenerationModelFetcher dataAccess;

        public CodeGeneratorServiceBase(CodeGeneratorTypes type, ICodeGenerationModelFetcher dataAccess)
        {
            this.type = type;
            this.dataAccess = dataAccess;
        }

        public virtual void Invoke()
        {
            //fetch data 
            var model = dataAccess.Get();

            //process data 
            var template = new DataAccessTemplate(dataAccess.Database, model).TransformText();

            //save data to disk
        }

        public abstract void Process();
    }
}
