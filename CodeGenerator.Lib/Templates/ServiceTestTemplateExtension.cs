using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ServiceTestTemplate
    {
        public readonly string namespaceName;

        public ServiceTestTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
