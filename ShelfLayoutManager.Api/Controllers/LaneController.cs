using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Lanes;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Skus;

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

        [HttpGet(Name = "lane")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{janCode}")]
        public async Task<ActionResult<List<Lane>>> Get(string janCode)
        {
            var result = await _application.GetLanesByJanCode(janCode);
            return Ok(result);
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
                return NotFound(ex);
            }
        }

        [HttpPut("{janCode}")]
        public async Task<ActionResult> Update(string janCode, [FromBody] Sku sku)
        {
            try
            {
                //await _application.UpdateSku(janCode, sku);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{janCode}")]
        public async Task<ActionResult> Delete(string janCode)
        {
            try
            {
                //await _application.DeleteSku(janCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
