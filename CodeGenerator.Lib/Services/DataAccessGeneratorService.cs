using CodeGenerator.Lib.DataAccess;
using System;

namespace CodeGenerator.Lib.Services
{

    public class DataAccessGeneratorService : CodeGeneratorServiceBase
    {
        public DataAccessGeneratorService(IDataAccess dataAccess) :base (dataAccess)
        { }

        public override void Invoke()
        {
            throw new NotImplementedException();
        }
    }
}
