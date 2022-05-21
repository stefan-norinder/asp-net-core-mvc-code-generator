using CodeGenerator.Console;
using CodeGenerator.Lib.DataAccess;
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

            var sut = new ParamsModel(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.ClassName);
            var propCollection = sut.Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Key);
            Assert.AreEqual("string", propCollection[0].Value);
            Assert.AreEqual("Age", propCollection[1].Key);
            Assert.AreEqual("int", propCollection[1].Value);
        }

    }
}