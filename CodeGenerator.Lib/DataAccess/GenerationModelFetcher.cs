using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.DataAccess
{
    public class GenerationModelFetcher : ICodeGenerationModelFetcher
    {
        private CodeGenerationModel codeGenerationModel {get;set;}

        public GenerationModelFetcher(string className)
        {
            CreateCodeGenerationModel(className);
        }

        private void CreateCodeGenerationModel(string className)
        {
            codeGenerationModel = new CodeGenerationModel { Classes = new List<Class> { new Class { Name = className } } };
        }

        public string Database => throw new NotImplementedException();

        public CodeGenerationModel Get()
        {
            return codeGenerationModel;
        }

        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTableNames()
        {
            throw new NotImplementedException();
        }
    }
}