using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class DeleteViewTemplate
    {
        public readonly string namespaceName;

        public DeleteViewTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
