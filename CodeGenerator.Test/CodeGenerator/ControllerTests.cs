using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using NUnit.Framework;

namespace CodeGenerator.Test
{
    public class ControllerTests
    {
        [Test]
        public void Run()
        {
            var factory = new Controller();
            factory.Run(CodeGeneratorTypes.DataAccess);
            
        }

    }
}