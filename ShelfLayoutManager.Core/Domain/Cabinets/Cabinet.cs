using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public class Cabinet
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public int Number { get; set; }
        public List<Row> Rows { get; set; }
        public Position Position { get; set; }
        public Size Size { get; set; }

        public Cabinet()
        {
                
        }

        public Cabinet(int number, List<Row> rows, Position position, Size size)
        {
            Number = number;
            Rows = rows;
            Position = position;
            Size = size;
        }
    }
}
