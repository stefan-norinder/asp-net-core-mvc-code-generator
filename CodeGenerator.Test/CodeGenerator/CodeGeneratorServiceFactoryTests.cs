using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class CodeGeneratorServiceFactoryTests
    {
        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var factory = new CodeGeneratorServiceFactory();
            var instance = factory.CreateInstance(CodeGeneratorTypes.DataAccess);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

        [Test]
        public void CreateInstances_ShouldBeOfCorrectType()
        {
            var factory = new CodeGeneratorServiceFactory();
            var instances = factory.CreateInstances(CodeGeneratorTypes.DataAccess);
            var type = instances.First().GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

    }
}