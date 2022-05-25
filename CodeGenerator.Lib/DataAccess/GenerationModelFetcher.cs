using CodeGenerator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class GenerationModelFetcher : ICodeGenerationModelFetcher
    {
        private CodeGenerationModel codeGenerationModel { get; set; }

        public GenerationModelFetcher(string namespaceName, IEnumerable<ParamClass> classes)
        {
            CreateCodeGenerationModel(namespaceName, classes);
        }

        private void CreateCodeGenerationModel(string namespaceName, IEnumerable<ParamClass> classes)
        {

            codeGenerationModel = new CodeGenerationModel(namespaceName)
            {
                Classes = classes.Select(x => new Class { Name = x.ClassName, Properties = x.Properties.ToProperties() })
            };
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

    public static class KeyValuePairCollectionExtensions
    {
        public static IEnumerable<Proprety> ToProperties(this IEnumerable<KeyValuePair<string, string>> keyValuesPairs)
        {
            if (keyValuesPairs == null) return Enumerable.Empty<Proprety>();
            return from keyValuePair in keyValuesPairs select new Proprety { Name = keyValuePair.Key, DataType = keyValuePair.Value };
        }
    }
}