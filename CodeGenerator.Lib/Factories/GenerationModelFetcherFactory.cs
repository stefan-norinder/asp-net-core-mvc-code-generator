using CodeGenerator.Lib.DataAccess;

namespace CodeGenerator.Lib.Factories
{
    public interface ICodeGenerationModelFetcherFactory
    {
        ICodeGenerationModelFetcher CreateInstance();
    }

    public class GenerationModelFetcherFactory : ICodeGenerationModelFetcherFactory
    {
        private readonly string[] args;

        public GenerationModelFetcherFactory(string[] args)
        {
            this.args = args;
        }

        public ICodeGenerationModelFetcher CreateInstance()
        {
            if (args.IsBasedOnDatasource()) return new GenerationModelFromDatabaseFetcher(args);
            
            return new GenerationModelFetcher(args);
        }

    }
}
