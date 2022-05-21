using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class CodeGenerationModel
    {
        public CodeGenerationModel(string namespaceName)
        {
            NamespaceName = namespaceName;
        }

        public string NamespaceName { get; private set; }
        public List<Class> Classes { get; set; } = new List<Class>();
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
    }

    public class Proprety
    {
        public string Name { get; set; }
        public string SqlDataType { get; set; }
    }
}
