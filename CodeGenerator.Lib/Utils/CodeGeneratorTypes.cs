using System;

namespace CodeGenerator.Lib.Utils
{
    [Flags]
    public enum CodeGeneratorTypes
    {
        None = 0,
        Api = 1,
        Controllers = 2,
        DataAccess = 4,
        Services = 16,
        Models = 32,
        WebRoot = 64,
        SolutionRoot = 128,
        ViewModels = 256,
        Views = 512,
        Test = 1024,
        All = Api | Controllers | DataAccess | Services | Models | WebRoot | SolutionRoot | ViewModels | Views | Test
    }
}
