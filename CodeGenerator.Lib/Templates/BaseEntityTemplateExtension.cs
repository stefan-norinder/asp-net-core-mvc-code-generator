using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class BaseEntityTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public BaseEntityTemplate(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
            Model = new Class { Name = "Base" };
        }

        public Class Model { get; }
    }
}
