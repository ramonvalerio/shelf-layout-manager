using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Skus;
using ShelfLayoutManager.Core.Domain.Skus;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkuController : ControllerBase
    {
        private readonly ILogger<CabinetController> _logger;
        private readonly ISkuApplication _application;

        public SkuController(ILogger<CabinetController> logger, ISkuApplication application)
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

        [HttpGet("{janCode}")]
        public async Task<ActionResult> Get(string janCode)
        {
            var result = await _application.GetSkuByJanCode(janCode);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Sku sku)
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

        [HttpPut("{janCode}")]
        public async Task<ActionResult> Update(string janCode, [FromBody] Sku sku)
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

        [HttpDelete("{janCode}")]
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
