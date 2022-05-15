using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Templates
{
    partial class DataAccessTemplate
    {

        public DataAccessTemplate(DataModel model)
        {
            Model = model;
        }

        public DataModel Model { get; set; }
    }
}
