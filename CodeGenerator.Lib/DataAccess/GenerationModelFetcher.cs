using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class GenerationModelFetcher : ICodeGenerationModelFetcher
    {
        private CodeGenerationModel codeGenerationModel { get; set; }

        public GenerationModelFetcher(string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes = null)
        {
            CreateCodeGenerationModel(namespaceName, className, propertiesAndDataTypes);
        }

        private void CreateCodeGenerationModel(string namespaceName, string className, IEnumerable<KeyValuePair<string, string>> propertiesAndDataTypes)
        {

            codeGenerationModel = new CodeGenerationModel(namespaceName)
            {
                Classes = new List<Class>
                {
                    new Class { Name = className, Properties = propertiesAndDataTypes.ToProperties() }
                }
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