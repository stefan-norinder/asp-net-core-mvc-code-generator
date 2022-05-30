using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ViewModelTemplate
    {
        public readonly string namespaceName;

        public ViewModelTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
