using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class DataAccessTests
    {
        private IDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new DataAccess();
            dataAccess.Initilize(@".\sqlexpress", "Databases");
        }

        [Test]
        public void GetTablesInDatabase()
        {
            
            var result = dataAccess.GetTableNames();
            Assert.AreEqual(11, result.Count() );
        }

        [Test]
        public void GetColumnNamesAndDatatypesForTable()
        {
            var result = dataAccess.GetColumnsWithDatatypes("Admins");
            Assert.AreEqual(2, result.Count());
        }
    }
}