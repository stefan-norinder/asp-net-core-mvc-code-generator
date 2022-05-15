using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeGenerator.Test
{
    public class ServiceTests
    {
        private DataAccessGeneratorService service;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IDataAccess>();
            mock.Setup(x => x.Get()).Returns(new DataModel
            {
                Tables = new List<Table>
                {
                    new Table
                    {
                        Name = "Foo",
                        Columns = new List<Column>
                        {
                            new Column {Name = "bar", SqlDataType = "int" }
                        }
                    }
                }

            });
            service = new DataAccessGeneratorService(CodeGeneratorTypes.DataAccess, mock.Object);
        }

        [Test]
        public void Run()
        {
            this.service.Invoke();

        }

    }
}