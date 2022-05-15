using CodeGenerator.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGeneratorServiceFactory
    {
        IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes type);
        ICodeGenerator CreateInstance(CodeGeneratorTypes type);
    }

    public class CodeGeneratorServiceFactory : ICodeGeneratorServiceFactory
    {
        public ICodeGenerator CreateInstance(CodeGeneratorTypes type)
        {
            switch (type)
            {
                case CodeGeneratorTypes.DataAccess:
                    return new DataAccessGeneratorService();
                case CodeGeneratorTypes.Api:
                case CodeGeneratorTypes.Controllers:
                case CodeGeneratorTypes.Factories:
                case CodeGeneratorTypes.Services:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }

        }

        public IEnumerable<ICodeGenerator> CreateInstances(CodeGeneratorTypes types)
        {
            var codeGenerators = new List<ICodeGenerator>();

            foreach (var type in Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>())
            {
                if (types.HasFlag(type))
                {
                    codeGenerators.Add(CreateInstance(type));
                }
            }
            return codeGenerators;
        }
    }
}
