using System;

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
}
