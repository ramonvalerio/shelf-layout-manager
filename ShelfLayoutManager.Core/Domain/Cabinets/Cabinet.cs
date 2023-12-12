using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.ValueObjects;

namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public class Cabinet
    {
        public int Number { get; set; }
        public List<Row> Rows { get; private set; }
        public Position Position { get; private set; }
        public Size Size { get; private set; }

        public Cabinet(int number, List<Row> rows, Position position, Size size)
        {
            Number = number;
            Rows = rows;
            Position = position;
            Size = size;
        }
    }
}
