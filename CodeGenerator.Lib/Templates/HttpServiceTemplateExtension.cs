using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.Templates
{
    partial class HttpServiceTemplate
    {
        public readonly string namespaceName;

        public HttpServiceTemplate(string namespaceName, Class @class)
        {
            this.namespaceName = namespaceName;
            Model = @class;
        }

        public Class Model { get; }
    }
}
