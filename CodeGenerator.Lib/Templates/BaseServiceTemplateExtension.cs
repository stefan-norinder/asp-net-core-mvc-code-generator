namespace CodeGenerator.Lib.Templates
{
    partial class BaseServiceTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public BaseServiceTemplate(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
        }
    }
}
