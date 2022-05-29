using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.Models
{
    public class ParamsModelFactory
    {
        public ParamsModel CreateInstance(string[] args)
        {
            if (args.Contains(ParamsConstants.Server) && args.Contains(ParamsConstants.DataSource)) return new ParamsModelFromDatasource(args);
            if (args.Contains(ParamsConstants.Namespace) && args.Contains(ParamsConstants.Class)) return new ManualParamsModel(args);
            throw new ArgumentException(string.Join(",",args));
        }
    }

    public class ParamsModel
    {
        public string Namespace { get; set; }
        public IEnumerable<ParamClass> Classes = new List<ParamClass>();
    }

    public class ParamsModelFromDatasource : ParamsModel
    {
        public ParamsModelFromDatasource(string[] args)
        {

        }
    }

    public class ManualParamsModel : ParamsModel
        {
            public ManualParamsModel(string[] args)
            {
                PopulateModelFromPassedArguments(args);
        }

        #region private 

        private void PopulateModelFromPassedArguments(string[] args)
        {
            var classes = new List<ParamClass>();
            ParamClass @class = null;
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == ParamsConstants.Namespace) Namespace = args[++i];
                if (args[i] == ParamsConstants.Class)
                {
                    if (@class != null) classes.Add(@class.Clone());
                    @class = new ParamClass(args[++i]);
                }
                if (args[i] == ParamsConstants.Properies)
                {
                    i++;
                    var list = new List<KeyValuePair<string, string>>();
                    while (i < args.Length && !args[i].Contains("--"))
                    {
                        list.Add(new KeyValuePair<string, string>(args[i++], args[i++]));
                    }
                    if (i < args.Length && args[i].Contains("--")) i--;
                    @class.Properties = list;
                }
            }
            if (@class != null) classes.Add(@class.Clone());
            Classes = classes;
        }

        #endregion
    }

    public class ParamClass
    {
        public ParamClass(string name)
        {
            ClassName = name;
        }

        public string ClassName { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Properties { get; set; }

        internal ParamClass Clone()
        {
            return new ParamClass(ClassName)
            {
                Properties = Properties.Select(x =>  new KeyValuePair<string,string>(x.Key, x.Value))
            };
        }
    }

    public static class ParamsConstants
    {
        public static string Help = "--help";
        public static string Namespace = "--namespace";
        public static string Class = "--class";
        public static string Properies = "--properties";
        public static string Server = "--server";
        public static string DataSource = "--datasource";
    }
}
