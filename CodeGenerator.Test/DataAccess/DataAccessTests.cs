using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
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
            var args = new[] { ParamsConstants.Namespace, "Foo", ParamsConstants.Server, ".\\sqlexpress", ParamsConstants.DataSource, "Databases" };
            fetcher = new GenerationModelFromDatabaseFetcher(args);
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