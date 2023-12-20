using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Rows
{
    public class Row
    {
        public int Number { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Lane> Lanes { get; set; }
        public float PositionZ { get; set; }
        public RowSize Size { get; set; }

        [JsonIgnore]
        public int CabinetNumber { get; set; }

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