using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class SqlDataAccessTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public SqlDataAccessTemplate(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
            Model = new Class { Name = "" };
        }

        public Class Model { get; }
    }
}
