namespace ShelfLayoutManager.Core.Domain.Skus
{
    public class Sku
    {
        public string JanCode { get; set; }

        public string Name { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public string ImageURL { get; set; }

        public int Size { get; set; }

        public long TimeStamp { get; set; }

        public string Shape { get; set; }
    }
}
