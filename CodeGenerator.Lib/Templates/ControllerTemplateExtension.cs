using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ControllerTemplate
    {
        public readonly string namespaceName;

        public ControllerTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
