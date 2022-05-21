using CodeGeneratorExample.Models;

namespace CodeGeneratorExample.Logic.DataAccess
{
    public interface IExampleDataAccess : IDataAccess<Example>
    {    }

    public class ExampleDataAccess : DataAccessBase<Example>, IExampleDataAccess
    {
        public ExampleDataAccess(ISqlDataAccess db, SqlStringBuilder<Example> sqlStringBuilder)
            : base(db, sqlStringBuilder)
        { }
     }
}
