using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application.Shelves;
using ShelfLayoutManager.Core.Domain.Shelves;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("shelf")]
    public class ShelfController : ControllerBase
    {
        private readonly ILogger<ShelfController> _logger;
        private readonly IShelfApplication _application;

        public ShelfController(ILogger<ShelfController> logger, IShelfApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<Shelf>> Get()
        {
            var result = await _application.GetShelf();
            return Ok(result);
        }
    }
}
