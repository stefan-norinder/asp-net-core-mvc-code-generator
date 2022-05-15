using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class DataModel
    {
        public List<Table> Tables { get; set; } = new List<Table>();
    }


    public class Table
    {
        public string Name { get; set; }
        public IEnumerable<Column> Columns { get; set; } = new List<Column>();

        public void AddColums(IEnumerable<Column> columns)
        {
            List<Column> initialList = Columns.ToList();
            List<Column> newColumns = columns.ToList();
            initialList.AddRange(newColumns);
            Columns = initialList;
        }
    }

    public class Column
    {
        public string Name { get; set; }
        public string SqlDataType { get; set; }
    }
}
