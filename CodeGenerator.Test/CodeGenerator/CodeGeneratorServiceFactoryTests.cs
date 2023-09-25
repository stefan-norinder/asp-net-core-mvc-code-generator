using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
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
            var loggerMock = new Mock<ILogger<Lib.CodeGenerators.CodeGenerator>>();
            var identifierTypeServiceMock = new Mock<IdentifierTypeService>();
            factory = new CodeGeneratorFactory(outputMock.Object, loggerMock.Object, identifierTypeServiceMock.Object);
        }

        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var instance = factory.CreateInstance(CodeGeneratorTypes.DataAccess, null);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGenerator), type);
        }

        [Test]
        public void CreateInstances_ShouldBeOfCorrectType()
        {
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess,  null);
            var type = instances.First().GetType();
            Assert.AreEqual(typeof(DataAccessGenerator), type);
        }

    }
}