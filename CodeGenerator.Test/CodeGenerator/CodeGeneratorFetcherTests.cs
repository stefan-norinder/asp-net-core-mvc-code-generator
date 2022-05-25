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
            var generator = new GenerationModelFetcher("Bar", CreateClasses("Foo"));
            var model = generator.Get();
            Assert.AreEqual("Foo", model.Classes.First().Name);
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