using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class DataAccessTests
    {
        private ICodeGenerationModelFetcher fetcher;

        [SetUp]
        public void Setup()
        {
            fetcher = new GenerationModelFromDatabaseFetcher(".\\SQLEXPRESS", "Databases");
        }

        [Test]
        public void GetTablesInDatabase()
        {
            
            var result = fetcher.GetTableNames();
            Assert.AreEqual(11, result.Count() );
        }

        [Test]
        public void GetColumnNamesAndDatatypesForTable()
        {
            var result = fetcher.GetColumnsWithDatatypes("Admins");
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetDataModel()
        {
            var result = fetcher.Get();
            Assert.AreEqual(11, result.Classes.Count());
            Assert.AreEqual(2, result.Classes.Single(x => x.Name == "Admins").Properties.Count());
        }
    }
}