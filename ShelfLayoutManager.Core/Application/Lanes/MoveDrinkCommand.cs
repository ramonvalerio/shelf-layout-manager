namespace ShelfLayoutManager.Core.Application.Lanes
{
    public class MoveDrinkCommand
    {
        public string JanCode { get; set; }
        public int FromCabinetNumber { get; set; }
        public int FromRowNumber { get; set; }
        public int FromLaneNumber { get; set; }
        public int ToCabinetNumber { get; set; }
        public int ToRowNumber { get; set; }
        public int ToLaneNumber { get; set; }
        public int Quantity { get; set; }
    }
}