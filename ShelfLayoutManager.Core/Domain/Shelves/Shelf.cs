using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Core.Domain.Shelves
{
    public class Shelf
    {
        public List<Cabinet> Cabinets { get; private set; }
        public Shelf(List<Cabinet> cabinets)
        {
            Cabinets = cabinets;
        }
    }
}