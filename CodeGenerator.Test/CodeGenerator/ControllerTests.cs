using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
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
            var expected = @"//---------------------------------------------------------------------------------------
                            // This is an auto generated file. Don't make any changes because they may be overwritten
                            //---------------------------------------------------------------------------------------

                            using Foo.Lib.Model;
                            using Foo.Lib.DataAccess;

                            namespace Foo.Lib.DataAccess
                            {
                                public interface IBarEntityDataAccess : IDataAccess<BarEntity>
                                {    }

                                public class BarEntityDataAccess : BaseDataAccess<BarEntity>, IBarEntityDataAccess
                                {
                                    public BarEntityDataAccess(ISqlDataAccess db, SqlStringBuilder<BarEntity> sqlStringBuilder)
                                        : base(db, sqlStringBuilder)
                                    { }
                                 }
                            }  ";
            controller.Run(CodeGeneratorTypes.DataAccess, CodeGeneratorFetcherTypes.FromString, "Foo", CreateClasses("Bar"));
            outputMock.Verify(x => x.Write(It.IsAny<string>(),It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));

        }

        [Test]
        public void CreateModelFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
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
            var classes = CreateClassWithPropertiesInsideList("Person");

            controller.Run(CodeGeneratorTypes.Models, CodeGeneratorFetcherTypes.FromString, "Example", classes);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        private IEnumerable<ParamClass> CreateClassWithPropertiesInsideList(string name)
        {
            var classes = CreateClasses(name);
            classes.First().Properties = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Name", "string"),
                new KeyValuePair<string, string>("Age", "int"),
            };
            return classes;
        }

        [Test]
        public void CreateServiceFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // This is an auto generated file. Don't make any changes because they may be overwritten
                            //---------------------------------------------------------------------------------------

                       using Example.Lib.DataAccess;
                        using Example.Lib.Model;
                        using Microsoft.Extensions.Logging;

                        namespace Example.Lib.Services
                        {
                            public interface IPersonService : IService<PersonEntity>
                            {
                            }

                            public class PersonService : Service<PersonEntity>, IPersonService
                            {
                                public PersonService(ILogger<PersonService> logger,
                                   IPersonEntityDataAccess dataAccess)
                                   : base(logger, dataAccess)
                                { }
                            }
                        }
                            ";

            var classes = CreateClassWithPropertiesInsideList("Persona");

            controller.Run(CodeGeneratorTypes.Services, CodeGeneratorFetcherTypes.FromString, "Example", classes);
            outputMock.Verify(x => x.Write(It.IsAny<string>(),It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        [Ignore("Not done")]
        [Test]
        public void CreateControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // This is an auto generated file. Don't make any changes because they may be overwritten
                            //---------------------------------------------------------------------------------------

                       using Example.Lib.DataAccess;
                        using Example.Lib.Model;
                        using Microsoft.Extensions.Logging;

                        namespace Example.Lib.Services
                        {
                            public interface IPersonService : IService<PersonEntity>
                            {
                            }

                            public class PersonService : Service<PersonEntity>, IPersonService
                            {
                                public PersonService(ILogger<PersonService> logger,
                                   IPersonEntityDataAccess dataAccess)
                                   : base(logger, dataAccess)
                                { }
                            }
                        }
                            ";

            var classes = CreateClassWithPropertiesInsideList("Person");

            controller.Run(CodeGeneratorTypes.Controllers, CodeGeneratorFetcherTypes.FromString, "Example",classes);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        [Test]
        public void CreateApiControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                        // This is an auto generated file. Don't make any changes because they may be overwritten
                        //---------------------------------------------------------------------------------------

                        using Example.Lib.Model;
                        using Example.Lib.Services;
                        using Microsoft.Extensions.Logging;
                        using Microsoft.AspNetCore.Mvc;
                        using Newtonsoft.Json;
                        using System.Collections.Generic;
                        using System.Threading.Tasks;

                        namespace Example.Web.ApiController
                        { 
                            [Route(""api/v1/[controller]"")]
                            [ApiController]
                            public class PersonController: ControllerBase
                            {
                                private readonly ILogger<PersonController> logger;
                                private readonly IPersonService service;

                                public PersonController(ILogger<PersonController> logger, IPersonService service)
                                {
                                    this.logger = logger;
                                    this.service = service;
                                }

                                [HttpGet]
                                public async Task<IEnumerable<string>> Get()
                                {
                                    var items = await service.GetAll();
                                    return JsonConvert.SerializeObject(items);
                                }

                                [HttpGet(""{id}"")]
                                public async Task<string> Get(int id)
                                {
                                    var item = await service.Get(id);
                                    return JsonConvert.SerializeObject(item);
                                }

                                [HttpPost]
                                public async Task Post([FromBody] string value)
                                {
                                   var item = JsonConvert.DeserializeObject<Person>(value);
                                   await service.Insert(item);
                                }

                                [HttpPut(""{id}"")]
                                public async Task Put(int id, [FromBody] string value)
                                {
                                   var item = JsonConvert.DeserializeObject<Person>(value);
                                   await service.Update(id, item);
                                }

                                [HttpDelete(""{id}"")]
                                public async Task Delete(int id)
                                {
                                       await service.Delete(id);
                                }
                            }
                        }";

            var classes = CreateClassWithPropertiesInsideList("Person");

            controller.Run(CodeGeneratorTypes.Api, CodeGeneratorFetcherTypes.FromString, "Example", classes);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));
        }


        private static bool AssertAreEqual(string expected, string actual)
        {
            return string.Compare(expected, actual, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
        }


        private IEnumerable<ParamClass> CreateClasses(params string[] names)
        {
            foreach (var name in names)
            {
                yield return new ParamClass(name);
            }
        }
    }
}