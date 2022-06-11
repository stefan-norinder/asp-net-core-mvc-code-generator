using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{

    public class GenerationModelFromDatabaseFetcher : ICodeGenerationModelFetcher
    {
        private readonly string server;
        private readonly string datasource;
        private readonly string output;
        private readonly string userId;
        private readonly string password;
        private readonly IDataAccess dataAccess;

        public string Namespace { get; private set; }
        public CodeGeneratorTypes GeneratorTypes { get; private set; }

        public GenerationModelFromDatabaseFetcher(IDataAccess dataAccess, string[] args)
        {
            Namespace = GetValueForArgument(ParamsConstants.Namespace, args);
            var generatorTypes = GetValueForArgument(ParamsConstants.GeneratorTypes, args);
            GeneratorTypes = ConvertToGeneratorTypes(generatorTypes);
            server = GetValueForArgument(ParamsConstants.Server, args);
            datasource = GetValueForArgument(ParamsConstants.DataSource, args);
            output = GetValueForArgument(ParamsConstants.Output, args);
            userId = GetValueForArgument(ParamsConstants.UserId, args);
            password = GetValueForArgument(ParamsConstants.Password, args);

            this.dataAccess = dataAccess;
            this.dataAccess.Initilize(server, datasource, userId, password);
        }

        public CodeGenerationModel Get()
        {
            var dataModel = GetDataModel();

            return GetDataModelPopulatedWithColumns(dataModel);
        }

        #region private

        private CodeGeneratorTypes ConvertToGeneratorTypes(string arg)
        {
            CodeGeneratorTypes returnValues = CodeGeneratorTypes.None;
            var splittedString = arg.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in Enum.GetValues(typeof(CodeGeneratorTypes)))
            {
                var @enum = (CodeGeneratorTypes)item;
                foreach (var str in splittedString)
                {
                    if (string.Equals(@enum.ToString(), str, StringComparison.OrdinalIgnoreCase))
                    {
                        returnValues |= @enum;
                    }
                }
            }
            return returnValues;
        }

        private static string GetValueForArgument(string argument, string[] args)
        {
            if (!args.Any(x => x == argument)) return string.Empty;
            var startIndex = Array.FindIndex(args, (str) =>
            {
                return str == argument;
            });
            startIndex++;
            int endIndex = default;
            for (var i = startIndex; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    endIndex = i;
                    break;
                }
            }
            if (endIndex == default) endIndex = args.Length;
            var returnstring = string.Empty;
            for (var i = startIndex; i < endIndex; i++)
            {
                returnstring += $"{args[i]} ";
            }
            return returnstring.Trim();
        }

        private CodeGenerationModel GetDataModelPopulatedWithColumns(CodeGenerationModel dataModel)
        {
            var classes = new List<Class>();
            foreach (var item in dataModel.Classes)
            {
                var tuples = dataAccess.GetColumnsWithDatatypes(item.Name);
                var columns = tuples.Select(x => new Proprety { Name = x.Item1, DataType = x.Item2 });
                classes.Add(new Class { Name = item.Name, Properties = new List<Proprety>(columns) });
            }
            return new CodeGenerationModel(Namespace, dataModel.MetaData) { Classes = classes };
        }

        private CodeGenerationModel GetDataModel()
        {
            var metaData = new CodeGenerationModel.CodeGenerationModelMetaData
            {
                Server = server,
                Datasource = datasource,
                Output = output,
                UserId = userId,
                Password = password
            };

            return new CodeGenerationModel(Namespace, metaData)
            {
                Classes = dataAccess.GetTableNames().Select(tableName => new Class { Name = tableName }).ToList()
            };
        }

        #endregion
    }
}