using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Rows;
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("row")]
    public class RowController : ControllerBase
    {
        private readonly ILogger<RowController> _logger;
        private readonly IRowApplication _application;

        public RowController(ILogger<RowController> logger, IRowApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<List<Row>>> Get()
        {
            var result = await _application.GetRows();
            return Ok(result);
        }

        [HttpGet("cabinet/{cabinetNumber}")]
        public async Task<ActionResult> Get(int cabinetNumber)
        {
            var result = await _application.GetRowsByCabinetNumber(cabinetNumber);
            return Ok(result);
        }

        [HttpGet("cabinet/{cabinetNumber}/number/{number}")]
        public async Task<ActionResult> Get(int cabinetNumber, int number)
        {
            var result = await _application.GetRowByCabinetNumber(cabinetNumber, number);
            return Ok(result);
        }

        [HttpPost("cabinet/{cabinetNumber}")]
        public async Task<ActionResult> Create(int cabinetNumber, [FromBody] RowCommand command)
        {
            await _application.CreateRow(cabinetNumber, command);
            return Ok();
        }

        [HttpPut("cabinet/{cabinetNumber}")]
        public async Task<ActionResult> Update(int cabinetNumber, [FromBody] Row row)
        {
            await _application.UpdateRow(cabinetNumber, row);
            return Ok();
        }

        [HttpDelete("cabinet/{cabinetNumber}/number/{number}")]
        public async Task<ActionResult> Delete(int cabinetNumber, int number)
        {
            await _application.DeleteRow(cabinetNumber, number);
            return Ok();
        }
    }
}
