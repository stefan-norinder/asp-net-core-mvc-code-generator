using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class SqlDataAccessTemplate
    {
        public readonly string namespaceName;

        public SqlDataAccessTemplate(string namespaceName)
        {
            this.namespaceName = namespaceName;
            Model = new Class { Name = "" };
        }

        public Class Model { get; }
    }
}
