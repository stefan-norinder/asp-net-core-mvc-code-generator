using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class GenerationModelFetcher : ICodeGenerationModelFetcher
    {
        private CodeGenerationModel codeGenerationModel { get; set; }

        public GenerationModelFetcher(string[] args)
        {
            codeGenerationModel = new CodeGenerationModel();
            PopulateModelFromPassedArguments(args);
        }

        #region private 

        private void PopulateModelFromPassedArguments(string[] args)
        {
            var classes = new List<Class>();
            Class @class = null;
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == ParamsConstants.Namespace) codeGenerationModel.Namespace = args[++i];
                if (args[i] == ParamsConstants.Class)
                {
                    if (@class != null) classes.Add(@class.Clone());
                    @class = new Class { Name = args[++i] };
                }
                if (args[i] == ParamsConstants.Properies)
                {
                    i++;
                    var list = new List<Proprety>();
                    while (i < args.Length && !args[i].Contains("--"))
                    {
                        list.Add(new Proprety { Name = args[i++], DataType = args[i++] });
                    }
                    if (i < args.Length && args[i].Contains("--")) i--;
                    @class.Properties = list;
                }
            }
            if (@class != null) classes.Add(@class.Clone());
            codeGenerationModel.Classes = classes;
        }

        #endregion

        public string Namespace => codeGenerationModel.Namespace;

        public CodeGeneratorTypes GeneratorTypes => throw new NotImplementedException();

        public CodeGenerationModel Get()
        {
            return codeGenerationModel;
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