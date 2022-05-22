using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class BaseServiceTemplate
    {
        public readonly string namespaceName;

        public BaseServiceTemplate(string namespaceName)
        {
            this.namespaceName = namespaceName;
            Model = new Class { Name = "Base" };
        }

        public Class Model { get; }
    }
}
