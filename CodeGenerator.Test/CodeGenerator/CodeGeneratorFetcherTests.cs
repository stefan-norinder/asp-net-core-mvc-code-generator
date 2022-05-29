using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using NUnit.Framework;
using System.Collections.Generic;
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
            var args = new[] { ParamsConstants.Namespace, "Foo", ParamsConstants.Server, ".\\sqlexpress", ParamsConstants.DataSource, "Databases" };
            var generator = new GenerationModelFetcher(args);
            var model = generator.Get();
            Assert.AreEqual("Foo", model.Classes.First().Name);
        }
    }
}