using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Test
{
    public class DataAccessTests
    {
        private SqlDataAccess dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new SqlDataAccess(".\\SQLEXPRESS", "Databases");
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

        [Test]
        public void GetDataModel()
        {
            var result = dataAccess.Get();
            Assert.AreEqual(11, result.Tables.Count());
            Assert.AreEqual(2, result.Tables.Single(x => x.Name == "Admins").Columns.Count());
        }
    }
}