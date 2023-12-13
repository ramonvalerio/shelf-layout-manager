using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Lanes
{
    public class Lane
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public int Number { get; set; }
        public string JanCode { get; set; }
        public int Quantity { get; set; }
        public float PositionX { get; set; }
        [JsonIgnore]
        public int RowId { get; set; }

        public Lane()
        {
                
        }

        public Lane(int number, string janCode, int quantity, float positionX)
        {
            Number = number;
            JanCode = janCode;
            Quantity = quantity;
            PositionX = positionX;
        }
    }
}