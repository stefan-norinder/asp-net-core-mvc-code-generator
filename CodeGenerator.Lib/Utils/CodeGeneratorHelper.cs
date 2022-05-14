using System;

namespace CodeGenerator.Lib
{
    public static class CodeGeneratorHelper
    {
        public static string CreateProperty(Type type, string name)
        {
            return $"public {type.ConventionalName()} {name} {{ get; set; }}";
        }

        #region private 

        #endregion
    }
}
