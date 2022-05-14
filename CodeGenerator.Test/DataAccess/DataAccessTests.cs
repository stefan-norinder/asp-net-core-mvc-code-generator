using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        public void GetTablesInDatabase()
        {
            var dataAccess = new SqlDataAccess(".\\SQLEXPRESS", "Databases");
            var result = dataAccess.GetTableNames();
            Assert.AreEqual(result.Count(), 11);
        }

        [Test]
        public void GetColumnNamesAndDatatypesForTable()
        {
            var dataAccess = new SqlDataAccess(".\\SQLEXPRESS", "Databases");
            var result = dataAccess.GetColumnsWithDatatypes("Admins");
            Assert.AreEqual(result.Count(), 2);
        }
    }
}