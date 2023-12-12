using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Domain.Rows
{
    public class Row
    {
        public int Number { get; set; }
        public List<Lane> Lanes { get; private set; }
        public float PositionZ { get; set; }
        public Size Size { get; set; }

        public Row(int number, float position, float height, List<Lane> lanes)
        {
            Number = number;
            PositionZ = position;
            Size = new Size(0, 0, height);
            Size.Height = height;
            Lanes = lanes;
        }
    }
}