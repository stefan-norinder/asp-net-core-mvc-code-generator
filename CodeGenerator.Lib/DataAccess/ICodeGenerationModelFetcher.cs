using CodeGenerator.Lib.Models;

namespace CodeGenerator.Lib.DataAccess
{
    public interface ICodeGenerationModelFetcher
    {
        CodeGenerationModel Get();
        string Namespace { get; }
    }
}