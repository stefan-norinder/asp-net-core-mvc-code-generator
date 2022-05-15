using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using NUnit.Framework;

namespace CodeGenerator.Test
{
    public class CodeGeneratorServiceFactoryTests
    {
        [Test]
        public void CreateInstance_ShouldBeOfCorrectType()
        {
            var factory = new CodeGeneratorServiceFactory();
            var instance = factory.CreateInstance(CodeGeneratorServiceTypes.DataAccess);
            var type = instance.GetType();
            Assert.AreEqual(typeof(DataAccessGeneratorService), type);
        }

    }
}