using CodeGenerator.Test.TestFiles;
using NUnit.Framework;

namespace CodeGenerator.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateCodeFromSimpleTemplate()
        {
            const string result = "public namespace CodeGenerator.TestTemplates\r\n{\r\n\tpublic class SimpleTest\r\n\t{\r\n\t\t\r\n\t}\r\n}";
            var code = new SimpleTestTemplate().TransformText();
            Assert.AreEqual(result, code);
        }
    }
}