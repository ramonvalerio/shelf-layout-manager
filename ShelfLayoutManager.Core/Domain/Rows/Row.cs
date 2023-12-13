using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Rows
{
    public class Row
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public int Number { get; set; }
        public List<Lane> Lanes { get; set; }
        public float PositionZ { get; set; }
        public RowSize Size { get; set; }

        [JsonIgnore]
        public int CabinetId { get; private set; }

        public Row()
        {

        }

        public Row(int number, float position, float height, List<Lane> lanes)
        {
            Number = number;
            PositionZ = position;
            Size = new RowSize(height);
            Size.Height = height;
            Lanes = lanes;
        }
    }
}