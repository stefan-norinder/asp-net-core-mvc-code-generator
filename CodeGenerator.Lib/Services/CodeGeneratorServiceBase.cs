using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Services
{
    public abstract class CodeGeneratorServiceBase : ICodeGenerator
    {
        protected readonly IDataAccess dataAccess;

        public CodeGeneratorServiceBase(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public abstract void Invoke();
    }
}
