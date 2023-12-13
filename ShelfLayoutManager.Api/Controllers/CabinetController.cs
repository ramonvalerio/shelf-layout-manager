using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Shelfs;
using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CabinetController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly ICabinetApplication _application;

        public CabinetController(ILogger<CabinetController> logger, ICabinetApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet(Name = "Cabinet")]
        public async Task<ActionResult<List<Cabinet>>> Get()
        {
            var result = await _application.GetCabinets();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cabinet>> Get(int id)
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
