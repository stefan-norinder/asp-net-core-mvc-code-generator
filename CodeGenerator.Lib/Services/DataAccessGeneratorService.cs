using CodeGenerator.Lib.DataAccess;
using System;

namespace CodeGenerator.Lib.Services
{

    public class DataAccessGeneratorService : CodeGeneratorServiceBase
    {
        public DataAccessGeneratorService(ICodeGenerationModelFetcher codeGenerationModelFetcher) : base(codeGenerationModelFetcher)
        { }

        public override void Process()
        {
            // generate files from temaplates
            throw new NotImplementedException();
        }
    }
}
