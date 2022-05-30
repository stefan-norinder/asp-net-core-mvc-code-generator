using System;

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
        WebRoot = 64,
        SolutionRoot = 128,
        ViewModels = 256,
        All = Api | DataAccess | Services | Models | WebRoot | SolutionRoot | ViewModels
    }
}
