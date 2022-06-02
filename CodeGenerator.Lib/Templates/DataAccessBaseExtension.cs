using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessBase
    {
        public readonly string namespaceName;

        public DataAccessBase(string namespaceName)
        {
            this.namespaceName = namespaceName;
        }
    }
}
