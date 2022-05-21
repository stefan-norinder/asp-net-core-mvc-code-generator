using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessTemplate
    {

        public DataAccessTemplate(CodeGenerationModel model)
        {
            Model = model;
        }

        public CodeGenerationModel Model { get; }
    }
}
