using CodeGenerator.Lib.Models;
using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.DataAccess
{
    public interface ICodeGenerationModelFetcher
    {
        CodeGenerationModel Get();
        string Namespace { get; }
        #region for test
        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table);
        public IEnumerable<string> GetTableNames();
        #endregion
    }
}