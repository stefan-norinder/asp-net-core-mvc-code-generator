using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ServiceTemplate
    {
        public readonly string namespaceName;

        public ServiceTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
