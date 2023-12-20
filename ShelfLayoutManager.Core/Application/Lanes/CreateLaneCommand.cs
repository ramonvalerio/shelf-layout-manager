namespace ShelfLayoutManager.Core.Application.Lanes
{
    public class CreateLaneCommand
    {
        public int CabinetNumber { get; set; }
        public int RowNumber { get; set; }
        public string JanCode { get; set; }
        public int Quantity { get; set; }
    }
}
