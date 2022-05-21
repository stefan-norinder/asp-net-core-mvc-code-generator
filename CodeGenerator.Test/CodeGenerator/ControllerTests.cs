using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;

namespace CodeGenerator.Test
{
    public class ControllerTests
    {
        private Controller controller;

        [SetUp]
        public void Setup()
        {
            var outputMock = new Mock<IOutputAdapter>();
            var factory = new CodeGeneratorServiceFactory(outputMock.Object);
            controller = new Controller(factory);
        }

        [Test]
        public void Run()
        {

            controller.Run(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString, "Foo", "Bar");
            
        }

    }
}