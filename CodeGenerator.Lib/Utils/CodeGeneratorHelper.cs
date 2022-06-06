using System;

namespace CodeGenerator.Lib
{
    public static class CodeGeneratorHelper
    {
        public static string CreateProperty(Type type, string name)
        {
            return $"public {type.ConventionalName()} {name} {{ get; set; }}";
        }

        public static string GetTemplateHeaderText()
        {
            return $@"
//---------------------------------------------------------------------------------------
// Warning! This is an auto generated file. Changes may be overwritten. 
// Generator version: { typeof(CodeGeneratorHelper).Assembly.GetName().Version }
// Created at: { DateTime.Now }
//---------------------------------------------------------------------------------------";
        }

        #region private 

        #endregion
    }
}
