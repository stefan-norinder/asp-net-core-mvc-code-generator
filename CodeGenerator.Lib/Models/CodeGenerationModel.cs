using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Models
{
    public class CodeGenerationModel
    {
        public CodeGenerationModel()
        {
        }
        public CodeGenerationModel(string @namespace)
        {
            Namespace = @namespace;
        }

        public string Namespace { get; set; }
        public IEnumerable<Class> Classes { get; set; } = new List<Class>();

        public override string ToString() => Namespace;
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
    }
}
