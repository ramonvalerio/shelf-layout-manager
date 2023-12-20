using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Skus;
using ShelfLayoutManager.Core.Domain.Skus;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("sku")]
    public class SkuController : ControllerBase
    {
        private readonly ILogger<SkuController> _logger;
        private readonly ISkuApplication _application;

        public SkuController(ILogger<SkuController> logger, ISkuApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet(Name = "sku")]
        public async Task<ActionResult> Get()
        {
            var result = await _application.GetSkus();
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
            await _application.CreateSku(sku);
            return Ok();
        }

        [HttpPut("{janCode}")]
        public async Task<ActionResult> Update(string janCode, [FromBody] Sku sku)
        {
            await _application.UpdateSku(janCode, sku);
            return Ok();
        }

        [HttpDelete("{janCode}")]
        public async Task<ActionResult> Delete(string janCode)
        {
            await _application.DeleteSku(janCode);
            return Ok();
        }
    }
}
