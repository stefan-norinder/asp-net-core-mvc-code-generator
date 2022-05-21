using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace CodeGenerator.Test
{
    public class CodeGeneratorServiceFactoryTests
    {
        private CodeGeneratorServiceFactory factory;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<ICodeGenerationModelFetcherFactory>();
            factory = new CodeGeneratorServiceFactory(mock.Object);
        }

        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var instance = factory.CreateInstance(CodeGeneratorTypes.DataAccess,CodeGeneratorFetcherTypes.FromString);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

        [Test]
        public void CreateInstances_ShouldBeOfCorrectType()
        {
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString);
            var type = instances.First().GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

        [Test]
        public void CreateGeneratorFetcherInstances_ShouldBeOfCorrectType()
        {
            throw new NotImplementedException();
            //factory = new CodeGeneratorServiceFactory("namespaceName","ClassName");
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString);
            var type = instances.First().GetType();
            //Assert.AreEqual(typeof(GeneratorService), type);
        }

    }
}