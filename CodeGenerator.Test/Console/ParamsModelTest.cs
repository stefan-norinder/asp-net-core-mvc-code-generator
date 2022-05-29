using CodeGenerator.Console;
using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Test
{
    public class ParamsModelTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructParamsModel()
        {
            var args = new[] {
                    "--namespace",
                    "Foo",
                    "--class",
                    "Bar",
                    "--properties",
                    "Inc",
                    "string",
                    "Age",
                    "int"
            };

            var sut = new ManualParamsModel(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Classes.First().ClassName);
            var propCollection = sut.Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Key);
            Assert.AreEqual("string", propCollection[0].Value);
            Assert.AreEqual("Age", propCollection[1].Key);
            Assert.AreEqual("int", propCollection[1].Value);
        }

        [Test]
        public void ConstructParamsModelWithMultipleClasses()
        {
            var args = new[] {
                    "--namespace",
                    "Foo",
                    "--class",
                    "Bar",
                    "--properties",
                    "Inc",
                    "string",
                    "Age",
                    "int",
                    "--class",
                    "Car",
                    "--properties",
                    "CarModel",
                    "string",
                    "Year",
                    "int"
            };

            var sut = new ManualParamsModel(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Classes.First().ClassName);
            var propCollection = sut.Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Key);
            Assert.AreEqual("string", propCollection[0].Value);
            Assert.AreEqual("Age", propCollection[1].Key);
            Assert.AreEqual("int", propCollection[1].Value);
            Assert.AreEqual("Car", sut.Classes.Last().ClassName);
            propCollection = sut.Classes.Last().Properties.ToList();
            Assert.AreEqual("CarModel", propCollection[0].Key);
            Assert.AreEqual("string", propCollection[0].Value);
            Assert.AreEqual("Year", propCollection[1].Key);
            Assert.AreEqual("int", propCollection[1].Value);
        }

        [Test]
        [Ignore("Not done")]
        public void ConstructParamsModelFromDatasourceParams()
        {
            // --namespace DatabaseTest --server .\sqlexpress --datasource test
            var args = new[] {
                    "--namespace",
                    "DatabaseTest",
                    "--server",
                    ".\\sqlexpress",
                    "--datasource",
                    "test"
            };

            var sut = new ParamsModelFromDatasource(args);

            Assert.AreEqual("DatabaseTest", sut.Namespace);
            //Assert.AreEqual("DatabaseTest", sut.D);
            Assert.AreEqual("Bar", sut.Classes.First().ClassName);
            var propCollection = sut.Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Key);
            Assert.AreEqual("string", propCollection[0].Value);
            Assert.AreEqual("Age", propCollection[1].Key);
            Assert.AreEqual("int", propCollection[1].Value);
        }


    }
}