namespace CodeGenerator.Lib.Templates
{
    partial class ViewModelBaseTemplate
    {
        public readonly string namespaceName;
        public readonly string identifierType;

        public ViewModelBaseTemplate(string namespaceName, string identifierType)
        {
            this.namespaceName = namespaceName;
            this.identifierType = identifierType;
        }
    }
}
