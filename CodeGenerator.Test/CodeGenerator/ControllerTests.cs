using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Moq;
using NUnit.Framework;
using System.Globalization;
namespace CodeGenerator.Test
{
    public class ControllerTests
    {
        private Controller controller;
        private Mock<IOutputAdapter> outputMock;
        private string[] args;
        [SetUp]
        public void Setup()
        {
            outputMock = new Mock<IOutputAdapter>();
            var dataAccessMock = new Mock<IDataAccess>();
            var factory = new CodeGeneratorFactory(outputMock.Object);
            controller = new Controller(factory, dataAccessMock.Object);
            args = new[] { ParamsConstants.Namespace, "Example", ParamsConstants.Class, "Person", ParamsConstants.GeneratorTypes, $"{CodeGeneratorTypes.DataAccess} {CodeGeneratorTypes.Model} {CodeGeneratorTypes.Service} {CodeGeneratorTypes.Controllers} {CodeGeneratorTypes.Api}" };
        }
        [Test]
        public void CreateDataAccessFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"using Example.Logic.Model;
using Example.Logic.DataAccess;

namespace Example.Logic.DataAccess
{
    public interface IPersonDataAccess : IDataAccess<Person>
    {    }

    public class PersonDataAccess : BaseDataAccess<Person>, IPersonDataAccess
    {
        public PersonDataAccess(ISqlDataAccess db, SqlStringBuilder<Person> sqlStringBuilder)
            : base(db, sqlStringBuilder)
        { }
     }
}";
            controller.Run(args);
            outputMock.Verify(x => x.Write("./src/Example.Logic/DataAccess", "PersonDataAccess.cs", It.Is<string>(template => Assert(expected, template))));
        }
        [Test]
        public void CreateModelFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"using System;
                            namespace Example.Logic.Model
                            {
                                public class Person : Entity
                                {
      
                                }
                            } ";
            controller.Run(args);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.Is<string>(x => x.Contains("Person")), It.Is<string>(template => Assert(expected, template))));
        }
        [Test]
        public void CreateServiceFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"
using Example.Logic.DataAccess;
using Example.Logic.Model;
using Microsoft.Extensions.Logging;

namespace Example.Logic.Services
{
    public partial interface IPersonService : IService<Person>
    {
    }

    public partial class PersonService : Service<Person>, IPersonService
    {
        public PersonService(ILogger<PersonService> logger,
           IPersonDataAccess dataAccess)
           : base(logger, dataAccess)
        { }
    }
}
";
            controller.Run(args);
            outputMock.Verify(x => x.Write("./src/Example.Logic/Service", "PersonService.cs", It.Is<string>(template => Assert(expected, template))));
        }
        [Test]
        public void CreateControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"using Example.Logic.Model;
using Example.Logic.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Example.Web.ApiController
{ 
    [Route(""api/v1/[controller]s"")]
    [ApiController]
    public partial class PersonController: ControllerBase
    {
        protected readonly ILogger<PersonController> logger;
        protected readonly IPersonService service;

        public PersonController(ILogger<PersonController> logger, IPersonService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var items = await service.GetAll();
            if (!items.Any()) return NotFound();
            return Ok(items);            
        }

        [HttpGet(""{id}"")]
        public virtual async Task<IActionResult> Get(int id)
        {
            
            var item = await service.Get(id);
            if (item == null) return NotFound();
            return Ok(item);            
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] dynamic value)
        {
            var item = JsonConvert.DeserializeObject<Person>(value.ToString());
            var newItem = await service.Insert(item);
            return CreatedAtAction(nameof(Post), new {id = newItem.Id }, newItem);
        }

        [HttpPut(""{id}"")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] dynamic value)
        {
            if (!await service.Exists(id)) return NotFound();
            var item = JsonConvert.DeserializeObject<Person>(value.ToString());
            item.Id = id;
            await service.Update(item);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete(""{id}"")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await service.Exists(id)) return NotFound();
            await service.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}";
            controller.Run(args);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.Is<string>(x => x.Contains("Controller")), It.Is<string>(template => Assert(expected, template))));
        }
        [Test]
        public void CreateApiControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"using Example.Logic.Model;
using Example.Logic.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Example.Web.ApiController
{ 
    [Route(""api/v1/[controller]s"")]
    [ApiController]
    public partial class PersonController: ControllerBase
    {
        protected readonly ILogger<PersonController> logger;
        protected readonly IPersonService service;

        public PersonController(ILogger<PersonController> logger, IPersonService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var items = await service.GetAll();
            if (!items.Any()) return NotFound();
            return Ok(items);            
        }

        [HttpGet(""{id}"")]
        public virtual async Task<IActionResult> Get(int id)
        {
            
            var item = await service.Get(id);
            if (item == null) return NotFound();
            return Ok(item);            
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] dynamic value)
        {
            var item = JsonConvert.DeserializeObject<Person>(value.ToString());
            var newItem = await service.Insert(item);
            return CreatedAtAction(nameof(Post), new {id = newItem.Id }, newItem);
        }

        [HttpPut(""{id}"")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] dynamic value)
        {
            if (!await service.Exists(id)) return NotFound();
            var item = JsonConvert.DeserializeObject<Person>(value.ToString());
            item.Id = id;
            await service.Update(item);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete(""{id}"")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await service.Exists(id)) return NotFound();
            await service.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}";
            controller.Run(args);
            outputMock.Verify(x => x.Write("./src/Example.Web/ApiController", "PersonApiController.cs", It.Is<string>(template => Assert(expected, template))));
        }

        private static bool Assert(string expected, string actual)
        {
            actual = actual.Substring(actual.IndexOf("using"));
            return string.Compare(expected, actual, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
        }
    }
}