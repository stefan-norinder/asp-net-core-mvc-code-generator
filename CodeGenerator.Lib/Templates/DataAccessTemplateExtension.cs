using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessTemplate
    {

        public DataAccessTemplate(string @namespace,CodeGenerationModel model)
        {
            Namespace = @namespace;
            Model = model;
        }

        public string Namespace { get; }
        public CodeGenerationModel Model { get; }
    }
}
