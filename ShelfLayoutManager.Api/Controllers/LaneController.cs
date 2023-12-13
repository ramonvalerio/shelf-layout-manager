using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Lanes;
using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaneController : ControllerBase
    {
        private readonly ILogger<LaneController> _logger;
        private readonly ILaneApplication _application;

        public LaneController(ILogger<LaneController> logger, ILaneApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet("{janCode}")]
        public async Task<ActionResult<List<Lane>>> Get(string janCode)
        {
            try
            {
                var result = await _application.GetLanesByJanCode(janCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting lanes by JAN code");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{cabinetNumber}/{janCode}")]
        public async Task<ActionResult> Get(int cabinetNumber, string janCode)
        {
            try
            {
                var result = await _application.GetLanesByJanCodeFromCabinet(cabinetNumber, janCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting lanes by JAN code From Cabinet");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{cabinetNumber}/{rowNumber}/{janCode}")]
        public async Task<ActionResult> Get(int cabinetNumber, int rowNumber, string janCode)
        {
            try
            {
                var result = await _application.GetLanesByJanCodeFromCabinetRow(cabinetNumber, rowNumber, janCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting lanes by JAN code From Row in a specific Cabinet");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{cabinetNumber}/{rowNumber}/{number}")]
        public async Task<ActionResult> Get(int cabinetNumber, int rowNumber, int number)
        {
            try
            {
                var result = await _application.GetLaneByNumberFromCabinetRow(cabinetNumber, rowNumber, number);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting a lane by Number From Row in a specific Cabinet");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(int cabinetNumber, int rowNumber, [FromBody] Lane lane)
        {
            try
            {
                await _application.CreateLaneFromCabinetRow(cabinetNumber, rowNumber, lane);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating lane");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{cabinetNumber}/{rowNumber}/{number}")]
        public async Task<ActionResult> Update(int cabinetNumber, int rowNumber, int number, [FromBody] Lane lane)
        {
            try
            {
                await _application.UpdateLaneFromCabinetRow(cabinetNumber, rowNumber, number, lane);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating lane");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{cabinetNumber}/{rowNumber}/{number}")]
        public async Task<ActionResult> Delete(int cabinetNumber, int rowNumber, int number)
        {
            try
            {
                await _application.DeleteLaneFromCabinetRow(cabinetNumber, rowNumber, number);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting lane");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
