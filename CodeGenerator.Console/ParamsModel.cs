﻿using System.Collections.Generic;

namespace CodeGenerator.Console
{
    public class ParamsModel
    {
        public ParamsModel(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == ParamsConstants.Namespace) Namespace = args[++i];
                if (args[i] == ParamsConstants.Class) ClassName = args[++i];
                if (args[i] == ParamsConstants.Properies)
                {
                    i++;
                    var list = new List<KeyValuePair<string, string>>();
                    while (i < args.Length && !args[i].Contains("--"))
                    {
                        list.Add(new KeyValuePair<string, string>(args[i++], args[i++]));
                    }
                    Properties = list;
                }
            }
        }

        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Properties { get; set; }

    }

    public static class ParamsConstants
    {
        public static string Help = "--help";
        public static string Namespace = "--namespace";
        public static string Class = "--class";
        public static string Properies = "--properties";
    }
}