using CodeGenerator.Lib.DataAccess;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class CodeGeneratorFetcherTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CunstructCodeGenerationModel()
        {
            var generator = new GenerationModelFetcher("Foo");
            var model = generator.Get();
            Assert.AreEqual("Foo",model.Classes.First().Name);
        }
    }
}