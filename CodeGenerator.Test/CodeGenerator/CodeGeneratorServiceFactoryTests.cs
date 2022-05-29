using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Test
{
    public class CodeGeneratorServiceFactoryTests
    {
        private CodeGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var outputMock = new Mock<FileWriterOutputAdapter>();
            factory = new CodeGeneratorFactory(outputMock.Object);
        }

        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var instance = factory.CreateInstance(CodeGeneratorTypes.DataAccess,CodeGeneratorFetcherTypes.FromString, "Foo", CreateClasses("Bar"), null);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGenerator), type);
        }

        [Test]
        public void CreateInstances_ShouldBeOfCorrectType()
        {
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString, "Foo", CreateClasses("Bar"), null);
            var type = instances.First().GetType();
            Assert.AreEqual(typeof(DataAccessGenerator), type);
        }


        private IEnumerable<ParamClass> CreateClasses(params string[] names)
        {
            foreach (var name in names)
            {
                yield return new ParamClass(name);
            }
        }

    }
}