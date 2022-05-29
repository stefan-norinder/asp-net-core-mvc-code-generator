using CodeGenerator.Lib.CodeGenerators;
using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeGenerator.Test
{
    public class ServiceTests
    {
        private DataAccessGenerator service;
        private Mock<FileWriterOutputAdapter> outputMock;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<ICodeGenerationModelFetcher>();
            mock.Setup(x => x.Get()).Returns(new CodeGenerationModel("Foo")
            {
                Classes = new List<Class>
                {
                    new Class
                    {
                        Name = "Foo",
                        Properties = new List<Proprety>
                        {
                            new Proprety {Name = "bar", DataType = "int" }
                        }
                    }
                }

            });
            outputMock = new Mock<FileWriterOutputAdapter>();
            service = new DataAccessGenerator(mock.Object, outputMock.Object);
        }

        [Test]
        public void Run()
        {
            this.service.Invoke();
        }

        [Test]
        public void RunWithDatabase()
        {
            var args = new[] { ParamsConstants.Namespace, "Databases", ParamsConstants.Server, ".\\sqlexpress", ParamsConstants.DataSource, "Databases" };
            var databaseService = new DataAccessGenerator(new GenerationModelFromDatabaseFetcher(args), outputMock.Object);
            databaseService.Invoke();
        }

    }
}