using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;

namespace CodeGenerator.Lib.DataAccess
{
    public interface ICodeGenerationModelFetcher
    {
        CodeGenerationModel Get();
        string Namespace { get; }
        CodeGeneratorTypes GeneratorTypes { get; }
    }
}