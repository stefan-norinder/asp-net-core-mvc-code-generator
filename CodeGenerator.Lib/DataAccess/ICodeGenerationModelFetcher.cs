using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Utils;
using System;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public interface ICodeGenerationModelFetcher
    {
        CodeGenerationModel Get();
        string Namespace { get; }
        CodeGeneratorTypes GeneratorTypes { get; }
    }

    public class CodeGenerationModelFetcherBase
    {

        protected static string GetValueForArgument(string argument, string[] args)
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

        protected CodeGeneratorTypes ConvertToGeneratorTypes(string arg)
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
    }
}