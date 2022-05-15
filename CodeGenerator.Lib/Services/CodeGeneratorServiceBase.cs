using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Services
{
    public abstract class CodeGeneratorServiceBase : ICodeGenerator
    {
        private readonly CodeGeneratorTypes type;
        protected readonly IDataAccess dataAccess;

        public CodeGeneratorServiceBase(CodeGeneratorTypes type, IDataAccess dataAccess)
        {
            this.type = type;
            this.dataAccess = dataAccess;
        }

        public virtual void Invoke()
        {
            //fetch data 
            var model = dataAccess.Get();

            //process data 

            //save data to disk
        }

        public abstract void Process();
    }
}
