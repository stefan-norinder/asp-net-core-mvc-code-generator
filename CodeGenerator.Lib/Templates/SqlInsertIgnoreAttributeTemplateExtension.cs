using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class SqlInsertIgnoreAttributeTemplate
    {
        public readonly string namespaceName;

        public SqlInsertIgnoreAttributeTemplate(string namespaceName)
        {
            this.namespaceName = namespaceName;
            Model = new Class { Name = "SqlInsertIgnoreAttribute" };
        }

        public Class Model { get; }
    }
}
