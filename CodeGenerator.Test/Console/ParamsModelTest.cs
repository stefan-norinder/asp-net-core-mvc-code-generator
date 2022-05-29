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

            var sut = new GenerationModelFetcher(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Get().Classes.First().Name);
            var propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Age", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
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

            var sut = new GenerationModelFetcher(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Get().Classes.First().Name);
            var propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Age", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
            Assert.AreEqual("Car", sut.Get().Classes.First().Name);
            propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("CarModel", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Year", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
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

            var sut = new GenerationModelFetcher(args);

            Assert.AreEqual("DatabaseTest", sut.Namespace);
            //Assert.AreEqual("DatabaseTest", sut.D);
            Assert.AreEqual("Bar", sut.Get().Classes.First().Name);
            var propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Age", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
        }


    }
}