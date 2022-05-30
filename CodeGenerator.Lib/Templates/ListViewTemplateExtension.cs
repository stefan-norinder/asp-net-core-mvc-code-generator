using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ListViewTemplate
    {
        public readonly string namespaceName;

        public ListViewTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
