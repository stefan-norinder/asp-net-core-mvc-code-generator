using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.DataAccess
{
    public interface ICodeGenerationModelFetcher
    {
        CodeGenerationModel Get();
        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table);
        public IEnumerable<string> GetTableNames();
        string Database { get; }
    }
}