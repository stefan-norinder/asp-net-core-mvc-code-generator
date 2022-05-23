using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Example.Logic.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly ILogger<BarController> logger;
        private readonly IBarService service;

        public BarController(ILogger<BarController> logger, IBarService service)
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

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var item = await service.Get(id);
            return JsonConvert.SerializeObject(item);
        }

        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var item = JsonConvert.DeserializeObject<Bar>(value);
            await service.Insert(item);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
            var item = JsonConvert.DeserializeObject<Bar>(value);
            await service.Update(id, item);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}
