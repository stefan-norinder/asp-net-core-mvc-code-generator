using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGenerationModelFetcherFactory
    {
        ICodeGenerationModelFetcher CreateInstance();
    }

    public class GenerationModelFetcherFactory : ICodeGenerationModelFetcherFactory
    {
        private readonly IDataAccess dataAccess;
        private readonly string[] args;

        public GenerationModelFetcherFactory(IDataAccess dataAccess, string[] args)
        {
            this.dataAccess = dataAccess;
            this.args = args;
        }

        public ICodeGenerationModelFetcher CreateInstance()
        {
            if (args.IsBasedOnDatasource()) return new GenerationModelFromDatabaseFetcher(dataAccess,args);
            
            return new GenerationModelFetcher(args);
        }

    }
}
