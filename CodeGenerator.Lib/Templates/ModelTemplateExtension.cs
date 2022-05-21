using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Templates
{
    partial class ModelTemplate
    {
        private readonly string namespaceName;

        public ModelTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
