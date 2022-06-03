using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class ModelTestsTemplate
    {
        public readonly string namespaceName;

        public ModelTestsTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
