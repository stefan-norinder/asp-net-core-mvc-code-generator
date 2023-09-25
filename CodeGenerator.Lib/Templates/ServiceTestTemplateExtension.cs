using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ServiceTestTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public ServiceTestTemplate(string namespaceName, Class @class,string identifierType)
        {
            this.namespaceName = namespaceName;
            Model = @class;
            this.identifierType = identifierType;
        }

        public Class Model { get; }
    }
}
