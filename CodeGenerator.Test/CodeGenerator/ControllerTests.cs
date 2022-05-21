using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
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
            var factory = new CodeGeneratorFactory(outputMock.Object);
            controller = new Controller(factory);
        }

        [Test]
        public void CreateDataAccessFromTemplate_ShouldBeCorrectContent()
        {
            var actual = @"//---------------------------------------------------------------------------------------
                            // This is an auto generated file. Don't make any changes because they may be overwritten
                            //---------------------------------------------------------------------------------------
                
                        namespace Foo.Logic.DataAccess
                        {
                            public interface IBarEntityDataAccess : IDataAccess<BarEntity>
                            {    }

                            public class BarEntityDataAccess : DataAccessBase<BarEntity>, IBarEntityDataAccess
                            {
                                public BarEntityDataAccess(ISqlDataAccess db, SqlStringBuilder<BarEntity> sqlStringBuilder)
                                    : base(db, sqlStringBuilder)
                                { }
                             }
                        } ";
            controller.Run(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString, "Foo", "Bar");
            outputMock.Verify(x => x.Write(It.Is<string[]>(templates => AssertAreEqual(actual,templates.First()))));
        }

        [Test]
        public void CreateModelFromTemplate_ShouldBeCorrectContent()
        {
            var actual = @"//---------------------------------------------------------------------------------------
                            // This is an auto generated file. Don't make any changes because they may be overwritten
                            //---------------------------------------------------------------------------------------

                        namespace Example.Lib.Model
                        {
                            public class PersonEntity : Entity
                            {
                                public string Name {get;set;}
                                public int Age {get;set;}
                            }
                        } ";
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Name", "string"),
                new KeyValuePair<string, string>("Age", "int"),
            };

            controller.Run(CodeGeneratorTypes.Models, CodeGeneratorFetcherTypes.FromString, "Example", "Person", list);
            outputMock.Verify(x => x.Write(It.Is<string[]>(templates => AssertAreEqual(actual, templates.First()))));
        }

        private static bool AssertAreEqual(string actual, string expected)
        {
            return string.Compare(expected, actual, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
        }
    }
}