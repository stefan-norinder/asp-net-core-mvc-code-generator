using System;

namespace CodeGenerator.Lib
{
    public static class CodeGeneratorHelper
    {
        public static string CreateProperty(Type type, string name)
        {
            return $"public {type.ConventionalName()} {name} {{ get; set; }}";
        }

        public static string GetTemplateHeaderText(string remark = "")
        {
            if (!string.IsNullOrEmpty(remark)) remark = $"\r\n// Remark: {remark}";
            return $@"
//--------------------------------------------------------------------------------------------------------------------
// Warning! This is an auto generated file. Changes may be overwritten. 
// Generator version: { typeof(CodeGeneratorHelper).Assembly.GetName().Version }{remark}
//--------------------------------------------------------------------------------------------------------------------";
        }

        #region private 

        #endregion
    }
}
