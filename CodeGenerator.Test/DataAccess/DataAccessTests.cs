using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Test
{
    public class DataAccessTests
    {
        private GenerationModelFromDatabase dataAccess;

        [SetUp]
        public void Setup()
        {
            dataAccess = new GenerationModelFromDatabase(".\\SQLEXPRESS", "Databases");
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
            Assert.AreEqual(11, result.Classes.Count());
            Assert.AreEqual(2, result.Classes.Single(x => x.Name == "Admins").Properies.Count());
        }
    }
}