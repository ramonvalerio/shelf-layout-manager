using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Shelfs;
using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("cabinet")]
    public class CabinetController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly ICabinetApplication _application;

        public CabinetController(ILogger<CabinetController> logger, ICabinetApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet(Name = "cabinet")]
        public async Task<ActionResult<List<Cabinet>>> Get()
        {
            var result = await _application.GetCabinets();
            return Ok(result);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Cabinet>> Get(int number)
        {
            var result = _application.GetCabinetByNumber(number);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cabinet cabinet)
        {
            return NotFound();
        }

        [HttpPut("{number}")]
        public async Task<ActionResult> Update(int number, [FromBody] Cabinet cabinet)
        {
            return NotFound();
        }

        [HttpDelete("{number}")]
        public async Task<ActionResult> Delete(int number)
        {
            return NotFound();
        }
    }
}
