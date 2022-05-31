using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class EditViewTemplate
    {
        public readonly string namespaceName;

        public EditViewTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
