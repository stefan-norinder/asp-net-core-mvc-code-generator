using CodeGenerator.Lib.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Models
{
    public class CodeGenerationModel
    {
        public CodeGenerationModel()
        {
        }

        public CodeGenerationModel(string @namespace, CodeGenerationModel.CodeGenerationModelMetaData metaData)
        {
            Namespace = @namespace;
            MetaData = metaData;
        }

        public string Namespace { get; set; }
        public CodeGenerationModelMetaData MetaData { get; }
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();

        public override string ToString() => Namespace;

        public class CodeGenerationModelMetaData
        {
            public string Server { get; set; }
            public string EscapedServerString => Server.Replace(@"\", @"\\");
            public string Datasource { get; set; }
            private string output;
            public string Output
            {
                get
                {
                    if (output == null) return string.Empty;
                    if(output.EndsWith("/") || output.EndsWith("\\")) return output;
                    return output + "/";
                }
                set
                {
                    output = value;
                }
            }
            public string UserId { get; set; }
            public string Password { get; set; }
        }
    }

    public class Class
    {
        public string Name { get; set; }
        public IEnumerable<Proprety> Properties { get; set; } = new List<Proprety>();

        public void AddProperties(IEnumerable<Proprety> columns)
        {
            var initialList = Properties.ToList();
            var newColumns = columns.ToList();
            initialList.AddRange(newColumns);
            Properties = initialList;
        }

        public override string ToString() => Name;

        internal Class Clone()
        {
            var @class = new Class
            {
                Name = Name,

            };
            @class.AddProperties(Properties);
            return @class;
        }
    }

    public class Proprety
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string ConventionalDatatype
        {
            get
            {
                if (DataType.ToLower().Trim().StartsWith("nvarchar")) return "string";
                if (DataType.ToLower().Trim().Contains("int")) return "int";
                if (DataType.ToLower().Trim().StartsWith("varchar")) return "string";
                if (DataType.ToLower().Trim() == "bit") return "bool";
                if (DataType.ToLower().Trim().Contains("date")) return "DateTime";
                if (DataType.ToLower().Trim().Contains("binary")) return "byte[]";
                if (DataType.ToLower().Trim().Contains("text")) return "string";
                if (DataType.ToLower().Trim() == "numeric") return "decimal";
                if (DataType.ToLower().Trim() == "money") return "decimal";
                if (DataType.ToLower().Trim() == "float") return "double";
                if (DataType.ToLower().Trim() == "nchar") return "string";
                return DataType;
            }
        }
    }

    public static class PropretyExtension
    {
        public static IEnumerable<Proprety> GetAllPropertiesExceptId(this IEnumerable<Proprety> properties)
        {
            return properties.Where(x => !x.Name.Equals("Id", System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
