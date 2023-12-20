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

        /// <summary>
        /// Gets the cabinet by its number.
        /// </summary>
        /// <param name="number">The number of the cabinet.</param>
        /// <returns>The cabinet if found; otherwise, NotFound.</returns>
        [HttpGet("{number}")]
        public async Task<ActionResult<Cabinet>> Get(int number)
        {
            if (number <= 0)
            {
                return BadRequest("Number must be positive.");
            }

            _logger.LogInformation($"Fetching cabinet with number: {number}");
            var result = await _application.GetCabinetByNumber(number);
            if (result == null)
            {
                _logger.LogWarning($"Cabinet with number {number} not found.");
                return NotFound($"Cabinet with number {number} not found.");
            }
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
