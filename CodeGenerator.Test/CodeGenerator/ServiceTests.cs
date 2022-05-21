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
            var mock = new Mock<ICodeGenerationModelFetcher>();
            mock.Setup(x => x.Get()).Returns(new CodeGenerationModel("Foo")
            {
                Classes = new List<Class>
                {
                    new Class
                    {
                        Name = "Foo",
                        Properies = new List<Proprety>
                        {
                            new Proprety {Name = "bar", SqlDataType = "int" }
                        }
                    }
                }

            });
            service = new DataAccessGeneratorService(mock.Object);
        }

        [Test]
        public void Run()
        {
            this.service.Invoke();
        }

        [Test]
        public void RunWithDatabase()
        {
            var databaseService = new DataAccessGeneratorService(new GenerationModelFromDatabaseFetcher(".\\sqlexpress", "Databases"));
            databaseService.Invoke();
        }

    }
}