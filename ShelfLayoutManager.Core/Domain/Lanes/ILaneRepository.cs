namespace ShelfLayoutManager.Core.Domain.Lanes
{
    public interface ILaneRepository
    {
        Task<List<Lane>> GetAllByJanCode(string janCode);
        Task<List<Lane>> GetAllByJanCodeFromCabinet(int cabinetNumber, string janCode);
        Task<List<Lane>> GetAllByFromCabinetRow(int cabinetNumber, int rowNumber);
        Task<List<Lane>> GetAllByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode);
        Task<Lane> GetByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number);
        Task CreateFromCabinetRow(int cabinetNumber, int rowNumber, Lane lane);
        Task UpdateFromCabinetRow(int cabinetNumber, int rowNumber, int number, Lane lane);
        Task DeleteFromCabinetRow(int cabinetNumber, int rowNumber, int number);
    }
}