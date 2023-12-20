namespace ShelfLayoutManager.Core.Application.Cabinets
{
    public class CreateCabinetCommand
    {
        public int Number { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }

        public bool IsValid() 
        {
            if (Number < 1)
                return false;

            return true;
        }
    }
}