using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class CodeGeneratorServiceFactoryTests
    {
        private CodeGeneratorServiceFactory factory;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IDataAccess>();
            factory = new CodeGeneratorServiceFactory(mock.Object);
        }

        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var instance = factory.CreateInstance(CodeGeneratorTypes.DataAccess);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

        [Test]
        public void CreateInstances_ShouldBeOfCorrectType()
        {
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess);
            var type = instances.First().GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

    }
}