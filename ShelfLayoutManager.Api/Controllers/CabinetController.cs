using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application;
using ShelfLayoutManager.Core.Domain.Cabinets;

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

        [HttpGet(Name = "Shelf")]
        public async Task<ActionResult> Get()
        {
            var result = _application.GetCabinets();

            return Ok(new { result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cabinet shelf)
        {
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cabinet shelf)
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
