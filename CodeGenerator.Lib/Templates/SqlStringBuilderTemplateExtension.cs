using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class SqlStringBuilderTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public SqlStringBuilderTemplate(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
            Model = new Class { Name = "SqlStringBuilder" };
        }

        public Class Model { get; }
    }
}
