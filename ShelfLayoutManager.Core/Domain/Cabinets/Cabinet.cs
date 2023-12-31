﻿using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public class Cabinet
    {
        public int Number { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Row> Rows { get; set; }
        public Position Position { get; set; }
        public Size Size { get; set; }

        public Cabinet()
        {
                
        }

        public Cabinet(int number,Position position, Size size)
        {
            Number = number;
            Position = position;
            Size = size;
        }
    }
}
