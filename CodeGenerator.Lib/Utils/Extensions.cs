using CodeGenerator.Lib.Models;
using System;
using System.Linq;

namespace CodeGenerator.Lib
{
    public static partial class TypeExtensions
    {
        public static string ConventionalName(this Type type)
        {
            switch (type.Name)
            {
                case "Int16":
                case "Int32":
                    return "int";
                case "String":
                    return "string";
                case "DateTime":
                    return "DateTime";
                case "Boolean":
                    return "bool";
                default:
                    throw new ArgumentException();
            }
        }
    }
    public static partial class StringExtensions
    {
        public static bool IsBasedOnDatasource(this string[] args)
        {
            if (args.Contains(ParamsConstants.Server) && args.Contains(ParamsConstants.DataSource)) return true;
            if (args.Contains(ParamsConstants.Namespace)) return false;
            throw new ArgumentException(string.Join(",",args));
        }
    }
}
