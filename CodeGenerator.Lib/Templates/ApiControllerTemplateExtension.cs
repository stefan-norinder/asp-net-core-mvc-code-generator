using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ApiControllerTemplate
    {
        public readonly string namespaceName;

        public ApiControllerTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
