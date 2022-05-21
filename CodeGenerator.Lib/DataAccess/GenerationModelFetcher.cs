using System;
using System.Collections.Generic;

namespace CodeGenerator.Lib.DataAccess
{
    public class GenerationModelFetcher : ICodeGenerationModelFetcher
    {
        private CodeGenerationModel codeGenerationModel {get;set;}

        public GenerationModelFetcher(string namespaceName, string className)
        {
            CreateCodeGenerationModel(namespaceName, className);
        }

        private void CreateCodeGenerationModel(string namespaceName, string className)
        {
            codeGenerationModel = new CodeGenerationModel (namespaceName) { Classes = new List<Class> { new Class { Name = className } } };
        }

        public string Namespace => throw new NotImplementedException();

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