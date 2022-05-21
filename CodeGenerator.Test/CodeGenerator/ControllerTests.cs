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
            var mock = new Mock<ICodeGeneratorServiceFactory>();
            controller = new Controller(mock.Object);
        }

        [Test]
        public void Run()
        {

            controller.Run(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString);
            
        }

    }
}