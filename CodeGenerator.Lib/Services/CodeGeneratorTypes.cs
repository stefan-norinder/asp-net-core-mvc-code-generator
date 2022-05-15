using System;

namespace CodeGenerator.Lib.Services
{
    [Flags]
    public enum CodeGeneratorTypes
    { 
        Api = 1,
        Controllers = 2,
        DataAccess = 4,
        Factories = 8,
        Services = 16,
        All = Api + Controllers + DataAccess + Factories + Services
    }
    public static class CodeGeneratorTypesExtensions
    {
        public static bool HasFlag(this CodeGeneratorTypes type, CodeGeneratorTypes checkflag)
        {
            return (type & checkflag) == checkflag;
        }
    }
}
