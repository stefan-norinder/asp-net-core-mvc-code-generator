using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Utils;
using NUnit.Framework;
using System.Linq;

namespace CodeGenerator.Test
{
    public class ParamsModelTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructParamsModel()
        {
            var args = new[] {
                    "--namespace",
                    "Foo",
                    "--class",
                    "Bar",
                    "--properties",
                    "Inc",
                    "string",
                    "Age",
                    "int"
            };

            var sut = new GenerationModelFetcher(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Get().Classes.First().Name);
            var propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Age", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
        }

        [Test]
        public void ConstructParamsModelWithMultipleClasses()
        {
            var args = new[] {
                    "--namespace",
                    "Foo",
                    "--class",
                    "Bar",
                    "--properties",
                    "Inc",
                    "string",
                    "Age",
                    "int",
                    "--class",
                    "Car",
                    "--properties",
                    "CarModel",
                    "string",
                    "Year",
                    "int"
            };

            var sut = new GenerationModelFetcher(args);

            Assert.AreEqual("Foo", sut.Namespace);
            Assert.AreEqual("Bar", sut.Get().Classes.First().Name);
            var propCollection = sut.Get().Classes.First().Properties.ToList();
            Assert.AreEqual("Inc", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Age", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
            Assert.AreEqual("Car", sut.Get().Classes.Last().Name);
            propCollection = sut.Get().Classes.Last().Properties.ToList();
            Assert.AreEqual("CarModel", propCollection[0].Name);
            Assert.AreEqual("string", propCollection[0].DataType);
            Assert.AreEqual("Year", propCollection[1].Name);
            Assert.AreEqual("int", propCollection[1].DataType);
        }

        [Test]
        public void ConstructParamsModelFromDatasourceParams()
        {
            var args = new[] {
                    "--generatorTypes",
                    "api",
                    "controllers",
                    "--namespace",
                    "DatabaseTest",
                    "--server",
                    ".\\sqlexpress",
                    "--datasource",
                    "test",
                    "--output",
                    "foo/bar"
            };

            var mock = new Moq.Mock<IDataAccess>();

            var sut = new GenerationModelFromDatabaseFetcher(mock.Object, args);

            Assert.AreEqual("DatabaseTest", sut.Namespace);
            var model = sut.Get();
            Assert.IsTrue(sut.GeneratorTypes.HasFlag(CodeGeneratorTypes.Api));
            Assert.IsTrue(sut.GeneratorTypes.HasFlag(CodeGeneratorTypes.Controllers));
            Assert.AreEqual("test", model.MetaData.Datasource);
            Assert.AreEqual("foo/bar/", model.MetaData.Output);
            Assert.AreEqual(".\\sqlexpress", model.MetaData.Server);
        }
    }
}