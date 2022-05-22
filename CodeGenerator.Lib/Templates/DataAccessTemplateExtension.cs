using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessTemplate
    {
        public readonly string namespaceName;

        public DataAccessTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
