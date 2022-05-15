using CodeGenerator.Lib.DataAccess;
using System;

namespace CodeGenerator.Lib.Services
{

    public class DataAccessGeneratorService : CodeGeneratorServiceBase
    {
        public DataAccessGeneratorService(CodeGeneratorTypes type, IDataAccess dataAccess) :base (type,dataAccess)
        { }

        public override void Process()
        {
            // generate files from temaplates
            throw new NotImplementedException();
        }
    }
}
