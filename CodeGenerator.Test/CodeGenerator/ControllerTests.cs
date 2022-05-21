using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System.Globalization;
using System.Linq;

namespace CodeGenerator.Test
{
    public class ControllerTests
    {
        private Controller controller;
        private Mock<IOutputAdapter> outputMock;

        [SetUp]
        public void Setup()
        {
            outputMock = new Mock<IOutputAdapter>();
            var factory = new CodeGeneratorServiceFactory(outputMock.Object);
            controller = new Controller(factory);
        }

        [Test]
        public void Run()
        {
            var actual = @"namespace Foo.Lib.DataAccess
                        {
                            public class BarDataAccess 
                            {
                                public string Bar {get;set;}
                            }
  
                        } ";
            controller.Run(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString, "Foo", "Bar");
            outputMock.Verify(x => x.Write(It.Is<string[]>(templates => AssertAreEqual(actual,templates.First()))));
        }

        private static bool AssertAreEqual(string actual, string expected)
        {
            return string.Compare(expected, actual, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
        }
    }
}