namespace ShelfLayoutManager.Core.Domain.Lanes
{
    public interface ILaneRepository : IReadBaseRepository<Lane>
    {
        Task<List<Lane>> GetAllByJanCode(string janCode);
        Task<List<Lane>> GetAllByJanCodeFromCabinet(int cabinetNumber, string janCode);
        Task<List<Lane>> GetAllFromCabinetRow(int cabinetNumber, int rowNumber);
        Task<List<Lane>> GetAllByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode);
        Task<Lane> GetByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number);
        Task<Lane> CreateFromCabinetRow(Lane lane);
        Task UpdateFromCabinetRow(int cabinetNumber, int rowNumber, int number, Lane lane);
        Task DeleteFromCabinetRow(int cabinetNumber, int rowNumber, int number);
    }
}