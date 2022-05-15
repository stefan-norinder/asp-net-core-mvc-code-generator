using CodeGenerator.Lib.Services;
using System;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorServiceFactory
    {
        ICodeGenerator CreateInstance(CodeGeneratorServiceTypes type);
    }

    public class CodeGeneratorServiceFactory : ICodeGeneratorServiceFactory
    {
        public ICodeGenerator CreateInstance(CodeGeneratorServiceTypes type)
        {
            switch (type)
            {
                case CodeGeneratorServiceTypes.DataAccess:
                    return new DataAccessGeneratorService();
                case CodeGeneratorServiceTypes.Api:
                case CodeGeneratorServiceTypes.Controllers:
                case CodeGeneratorServiceTypes.Factories:
                case CodeGeneratorServiceTypes.Services:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }
    }

    public enum CodeGeneratorServiceTypes
    { 
        Api = 1,
        Controllers = 2,
        DataAccess = 3,
        Factories = 4,
        Services = 5 
    }
}
