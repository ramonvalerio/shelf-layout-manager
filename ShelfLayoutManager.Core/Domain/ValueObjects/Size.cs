using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public class Size
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float Width { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float Depth { get; set; }
        public float Height { get; set; }

        public Size(float with, float depth, float height)
        {
            Width = with;
            Depth = depth;
            Height = height;
        }
    }
}