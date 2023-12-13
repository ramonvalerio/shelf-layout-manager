namespace ShelfLayoutManager.Core.Domain.SKUs
{
    public class SKU
    {
        public string JanCode { get; set; }
        public string Name { get; set; }
        public string DrinkSize { get; set; }
        public ProductSize Size { get; set; }
        public string ShapeType { get; set; }
        public string ImageUrl { get; set; } 
        public DateTime TimeStamp { get; set; }
    }
}
