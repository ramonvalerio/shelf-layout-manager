using CsvHelper;
using ShelfLayoutManager.Core.Domain.SKUs;
using System.Globalization;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class CSVService
    {
        public List<SKU> ParseSkuCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<SKU>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = new SKU
                    {
                        JanCode = csv.GetField("JanCode"),
                        Name = csv.GetField("Name"),
                        X = csv.GetField<float>("X"),
                        Y = csv.GetField<float>("Y"),
                        Z = csv.GetField<float>("Z"),
                        ImageURL = csv.GetField("ImageURL"),
                        Size = csv.GetField<int>("Size"),
                        TimeStamp = csv.GetField<long>("TimeStamp"),
                        Shape = csv.GetField("Shape")
                    };
                    records.Add(record);
                }
                return records;
            }
        }
    }
}