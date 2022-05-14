using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class DataAccessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetColumnsInDatabase()
        {
            var dataAccess = new SqlDataAccess(".\\SQLEXPRESS", "Databases");
            var result = dataAccess.ExecuteQuery();
            Assert.AreEqual(result.Count(), 11);
        }
    }
}