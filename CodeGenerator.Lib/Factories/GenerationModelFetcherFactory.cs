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
            ICodeGenerationModelFetcher generationModel = args.IsBasedOnDatasource() ? new GenerationModelFromDatabaseFetcher(dataAccess, args) : new GenerationModelFetcher(args);
            if (generationModel.Namespace.Contains("-")) throw new System.Exception("Invalid namespace name, cannot contain \"-\".");
            return generationModel;
        }

    }
}
