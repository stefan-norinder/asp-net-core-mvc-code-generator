using CodeGenerator.Lib;
using NUnit.Framework;
using System;

namespace CodeGenerator.Test.CodeGenerator
{
    public class CodeGeneratorHelperTests
    {
        [TestCase("System.Int32", "foo", "public int foo { get; set; }")]
        [TestCase("System.String", "bar", "public string bar { get; set; }")]
        [TestCase("System.DateTime", "int", "public DateTime inc { get; set; }")]
        [TestCase("System.Boolean", "nak", "public bool nak { get; set; }")]
        public void CreateProperty(string typeStr, string name, string expected)
        {
            var type = Type.GetType(typeStr);
            var result = CodeGeneratorHelper.CreateProperty(type, name);
            Assert.AreEqual(result, result);
        }
    }
}
