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
            var factory = new CodeGeneratorFactory(outputMock.Object);
            controller = new Controller(factory);
            args = new[] { ParamsConstants.Namespace, "Example", ParamsConstants.Class, "Person" };
        }

        [Test]
        public void CreateDataAccessFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // Warning! This is an auto generated file. Changes may be overwritten 
                            //---------------------------------------------------------------------------------------

                            using Example.Logic.Model;
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
                            } ";
            controller.Run(CodeGeneratorTypes.DataAccess, args);
            outputMock.Verify(x => x.Write("./src/Example.Logic/DataAccess", "PersonDataAccess.cs", It.Is<string>(template => AssertAreEqual(expected, template))));

        }

        [Test]
        public void CreateModelFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // Warning! This is an auto generated file. Changes may be overwritten 
                            //---------------------------------------------------------------------------------------

                            using System;

                            namespace Example.Logic.Model
                            {
                                public class Person : Entity
                                {
      
                                }
                            } ";

            controller.Run(CodeGeneratorTypes.Models, args);
            outputMock.Verify(x => x.Write("./src/Example.Logic/Model", "PersonModel.cs", It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        [Test]
        public void CreateServiceFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // Warning! This is an auto generated file. Changes may be overwritten 
                            //---------------------------------------------------------------------------------------

                            using Example.Logic.DataAccess;
                            using Example.Logic.Model;
                            using Microsoft.Extensions.Logging;

                            namespace Example.Logic.Services
                            {
                                public interface IPersonService : IService<Person>
                                {
                                }

                                public class PersonService : Service<Person>, IPersonService
                                {
                                    public PersonService(ILogger<PersonService> logger,
                                       IPersonDataAccess dataAccess)
                                       : base(logger, dataAccess)
                                    { }
                                }
                            }";

            controller.Run(CodeGeneratorTypes.Services, args);
            outputMock.Verify(x => x.Write("./src/Example.Logic/Service", "PersonService.cs", It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        [Test]
        public void CreateControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // Warning! This is an auto generated file. Changes may be overwritten 
                            //---------------------------------------------------------------------------------------

                            using AutoMapper;
                            using Example.Logic.Model;
                            using Example.Logic.Services;
                            using Microsoft.AspNetCore.Mvc;
                            using Microsoft.Extensions.Logging;
                            using System.Collections.Generic;
                            using System.Threading.Tasks;
                            using DatabaseTest.Web.ViewModel;

                            namespace Example.Web.Controllers
                            {
                                public class PersonController : Controller
                                {
                                    private readonly ILogger<PersonController> logger;
                                    private readonly IPersonService service;
                                    private readonly IMapper mapper;

                                    public PersonController(ILogger<PersonController> logger, 
                                    IPersonService service, 
                                    IMapper mapper)
                                    {
                                        this.logger = logger;
                                        this.service = service;
                                        this.mapper = mapper;
                                    }

                                    public async Task<IActionResult> Index()
                                    {
                                        var list = await service.GetAll();
                                        var viewModels = mapper.Map < IEnumerable<PersonViewModel>>(list);
                                        return View(viewModels);
                                    }
        
                                        public ActionResult Create()
                                    {
                                        return View();
                                    }

                                    [HttpPost]
                                    public async Task<ActionResult> Create([FromForm]PersonViewModel viewModel)
                                    {
                                        try
                                        {                
                                            var model = mapper.Map<Person>(viewModel);
                                            await service.Insert(model);
                                            return RedirectToAction(nameof(Index));
                                        }
                                        catch
                                        {
                                            return View();
                                        }
                                    }

                                    public async Task<ActionResult> Edit(int id)
                                    {
                                        var entity = await service.Get(id);
                                        return View(mapper.Map<PersonViewModel>(entity));
                                    }


                                    [HttpPost]
                                    public async Task<ActionResult> Edit([FromForm]PersonViewModel viewModel)
                                    {
                                        try
                                        {                
                                            var model = mapper.Map<Person>(viewModel);
                                            await service.Update(model);
                                            return RedirectToAction(nameof(Index));
                                        }
                                        catch
                                        {
                                            return View();
                                        }
                                    }

                                    public async Task<ActionResult> Delete(int id)
                                    {
                                        var entity = await service.Get(id);
                                        return View(mapper.Map<PersonViewModel>(entity));
                                    }

                                    [HttpPost]
                                    public async Task<ActionResult> Delete([FromForm]PersonViewModel viewModel)
                                    {
                                        try
                                        {                
                                            var model = mapper.Map<Person>(viewModel);
                                            await service.Delete(model.Id);
                                            return RedirectToAction(nameof(Index));
                                        }
                                        catch
                                        {
                                            return View();
                                        }
                                    }
                                }
                            }";

            controller.Run(CodeGeneratorTypes.Controllers, args);
            outputMock.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<string>(), It.Is<string>(template => AssertAreEqual(expected, template))));
        }

        [Test]
        public void CreateApiControllerFromTemplate_ShouldBeCorrectContent()
        {
            var expected = @"//---------------------------------------------------------------------------------------
                            // Warning! This is an auto generated file. Changes may be overwritten 
                            //---------------------------------------------------------------------------------------

                            using Example.Logic.Model;
                            using Example.Logic.Services;
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
                                    public async Task<string> Get()
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
                                    public async Task Post([FromBody] dynamic value)
                                    {
                                       var item = JsonConvert.DeserializeObject<Person>(value.ToString());
                                       await service.Insert(item);
                                    }

                                    [HttpPut(""{id}"")]
                                    public async Task Put(int id, [FromBody] dynamic value)
                                    {
                                       var item = JsonConvert.DeserializeObject<Person>(value.ToString());
                                       item.Id = id;
                                       await service.Update(item);
                                    }

                                    [HttpDelete(""{id}"")]
                                    public async Task Delete(int id)
                                    {
                                           await service.Delete(id);
                                    }
                                }
                            }";

            controller.Run(CodeGeneratorTypes.Api, args);
            outputMock.Verify(x => x.Write("./src/Example.Web/ApiController", "PersonApiController.cs", It.Is<string>(template => AssertAreEqual(expected, template))));
        }


        private static bool AssertAreEqual(string expected, string actual)
        {
            return string.Compare(expected, actual, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
        }
    }
}