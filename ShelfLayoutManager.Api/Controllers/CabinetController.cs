using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Shelves;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CabinetController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly IShelfApplication _application;

        public CabinetController(ILogger<CabinetController> logger, IShelfApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet(Name = "Cabinet")]
        public async Task<ActionResult> Get()
        {
            var result = await _application.GetShelf();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = _application.GetCabinetByNumber(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cabinet cabinet)
        {
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cabinet cabinet)
        {
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return NotFound();
        }
    }
}
