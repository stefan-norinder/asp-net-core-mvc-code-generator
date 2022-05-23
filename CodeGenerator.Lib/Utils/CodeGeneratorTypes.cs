﻿using System;

namespace CodeGenerator.Lib.Utils
{
    [Flags]
    public enum CodeGeneratorTypes
    {
        Api = 1,
        Controllers = 2,
        DataAccess = 4,
        Services = 16,
        Models = 32,
        All = Api | DataAccess | Services | Models
    }

    public static class CodeGeneratorTypesExtensions
    {
        public static bool HasFlag(this CodeGeneratorTypes type, CodeGeneratorTypes checkflag)
        {
            return (type & checkflag) == checkflag;
        }
    }
}
