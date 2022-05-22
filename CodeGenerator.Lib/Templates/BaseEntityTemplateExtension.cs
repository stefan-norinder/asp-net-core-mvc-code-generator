using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class BaseEntityTemplate
    {
        public readonly string namespaceName;

        public BaseEntityTemplate(string namespaceName)
        {
            this.namespaceName = namespaceName;
            Model = new Class { Name = "Base" };
        }

        public Class Model { get; }
    }
}
