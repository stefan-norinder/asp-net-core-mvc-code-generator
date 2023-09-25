using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessBase
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public DataAccessBase(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
        }
    }
}
