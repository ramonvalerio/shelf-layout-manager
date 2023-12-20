using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Lanes;
using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("lane")]
    public class LaneController : ControllerBase
    {
        private readonly ILogger<LaneController> _logger;
        private readonly ILaneApplication _application;

        public LaneController(ILogger<LaneController> logger, ILaneApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lane>>> Get()
        {
            var result = await _application.GetLanes();
            return Ok(result);
        }

        [HttpGet("cabinet/{cabinetNumber}/jancode/{janCode}")]
        public async Task<ActionResult> Get(int cabinetNumber, string janCode)
        {
            var result = await _application.GetLanesByJanCodeFromCabinet(cabinetNumber, janCode);
            return Ok(result);
        }

        [HttpGet("cabinet/{cabinetNumber}/row/{rowNumber}/jancode/{janCode}")]
        public async Task<ActionResult> Get(int cabinetNumber, int rowNumber, string janCode)
        {
            var result = await _application.GetLanesByJanCodeFromCabinetRow(cabinetNumber, rowNumber, janCode);
            return Ok(result);
        }

        [HttpGet("cabinet/{cabinetNumber}/row/{rowNumber}/number/{number}")]
        public async Task<ActionResult> Get(int cabinetNumber, int rowNumber, int number)
        {
            var result = await _application.GetLaneByNumberFromCabinetRow(cabinetNumber, rowNumber, number);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateLaneCommand command)
        {
            await _application.CreateLaneFromCabinetRow(command);
            return Ok();
        }

        [HttpPut("cabinet/{cabinetNumber}/row/{rowNumber}")]
        public async Task<ActionResult> Update(int cabinetNumber, int rowNumber, [FromBody] Lane lane)
        {
            await _application.UpdateLaneFromCabinetRow(cabinetNumber, rowNumber, lane.Number, lane);
            return Ok();
        }

        [HttpDelete("cabinet/{cabinetNumber}/row/{rowNumber}/number/{number}")]
        public async Task<ActionResult> Delete(int cabinetNumber, int rowNumber, int number)
        {
            await _application.DeleteLaneFromCabinetRow(cabinetNumber, rowNumber, number);
            return Ok();
        }

        [HttpPost("MoveDrink")]
        public async Task<ActionResult> MoveDrink([FromBody] MoveDrinkCommand command)
        {
            await _application.MoveDrink(command);
            return Ok();
        }
    }
}
