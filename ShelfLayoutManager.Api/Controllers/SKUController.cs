using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.SKUs;
using ShelfLayoutManager.Core.Domain.SKUs;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SKUController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly ISKUApplication _application;

        public SKUController(ILogger<CabinetController> logger, ISKUApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet(Name = "SKU")]
        public async Task<ActionResult> Get()
        {
            var result = await _application.GetSAllSku();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var result = await _application.GetSkuByJanCode(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SKU sku)
        {
            try
            {
                await _application.CreateSku(sku);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string janCode, [FromBody] SKU sku)
        {
            try
            {
                await _application.UpdateSku(janCode, sku);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string janCode)
        {
            try
            {
                await _application.DeleteSku(janCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
