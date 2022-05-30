using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class CreateViewTemplate
    {
        public readonly string namespaceName;

        public CreateViewTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
