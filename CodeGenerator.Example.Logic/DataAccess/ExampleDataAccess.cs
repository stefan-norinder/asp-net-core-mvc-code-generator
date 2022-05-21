using CodeGenerator.Example.Models;

namespace CodeGenerator.Example.Logic.DataAccess
{
    public interface IExampleEntityDataAccess : IDataAccess<ExampleEntity>
    {    }

    public class ExampleEntityDataAccess : DataAccessBase<ExampleEntity>, IExampleEntityDataAccess
    {
        public ExampleEntityDataAccess(ISqlDataAccess db, SqlStringBuilder<ExampleEntity> sqlStringBuilder)
            : base(db, sqlStringBuilder)
        { }
     }
}
