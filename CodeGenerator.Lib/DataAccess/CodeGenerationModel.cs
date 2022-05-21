﻿using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class CodeGenerationModel
    {
        public List<Class> Classes { get; set; } = new List<Class>();
    }

    public class Class
    {
        public string Name { get; set; }
        public IEnumerable<Proprety> Properies { get; set; } = new List<Proprety>();

        public void AddProperties(IEnumerable<Proprety> columns)
        {
            var initialList = Properies.ToList();
            var newColumns = columns.ToList();
            initialList.AddRange(newColumns);
            Properies = initialList;
        }
    }

    public class Proprety
    {
        public string Name { get; set; }
        public string SqlDataType { get; set; }
    }
}