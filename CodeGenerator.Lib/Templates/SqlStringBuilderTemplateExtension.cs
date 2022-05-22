using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class SqlStringBuilderTemplate
    {
        public readonly string namespaceName;

        public SqlStringBuilderTemplate(string namespaceName)
        {
            this.namespaceName = namespaceName;
            Model = new Class { Name = "SqlStringBuilder" };
        }

        public Class Model { get; }
    }
}
