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
        Models = 32, 
        All = DataAccess | Services | Models
    }
    public static class CodeGeneratorTypesExtensions
    {
        public static bool HasFlag(this CodeGeneratorTypes type, CodeGeneratorTypes checkflag)
        {
            return (type & checkflag) == checkflag;
        }

        //public static CodeGeneratorTypes All()
        //{

        //    return (int) CodeGeneratorTypes.DataAccess + (int)CodeGeneratorTypes.Models + (int) CodeGeneratorTypes.Services;
        //// All = Api + Controllers + DataAccess + Factories + Services + Models
        //}
    }
}
