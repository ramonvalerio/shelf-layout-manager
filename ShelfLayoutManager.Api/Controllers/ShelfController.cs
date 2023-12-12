using Microsoft.AspNetCore.Mvc;
using ShelfLayoutManager.Core.Application;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Shelves;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelfController : ControllerBase
    {
        private readonly ILogger<ShelfController> _logger;

        public ShelfController(ILogger<ShelfController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Shelf")]
        public async Task<ActionResult> Get()
        {
            var lanes = new List<Lane>();
            lanes.Add(new Lane(1, "101", 5, 0));
            lanes.Add(new Lane(2, "201", 10, 1));
            lanes.Add(new Lane(3, "301", 15, 2));

            var rows = new List<Row>();
            rows.Add(new Row(1, 0, 10, lanes));
            rows.Add(new Row(2, 1, 30, lanes));
            rows.Add(new Row(3, 2, 50, lanes));

            var position = new Position { X = 10, Y = 20, Z = 30 };
            var size = new Size(100, 5, 80);

            var cabinet1 = new Cabinet(1, rows, position, size);
            var cabinet2 = new Cabinet(2, rows, position, size);
            var cabinet3 = new Cabinet(3, rows, position, size);

            var cabinets = new List<Cabinet> { cabinet1, cabinet2, cabinet3 };
            var shelf = new Shelf(cabinets);

            //var options = new JsonSerializerOptions
            //{
            //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            //};

            //var result = JsonSerializer.Serialize(shelf, options);

            return Ok(new { cabinets });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Cabinet shelf)
        {
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Cabinet shelf)
        {
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return NotFound();
        }
    }
}
