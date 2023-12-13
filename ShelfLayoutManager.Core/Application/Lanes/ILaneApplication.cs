using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public interface ILaneApplication
    {
        Task<List<Lane>> GetLanesByJanCode(string janCode);
        Task<List<Lane>> GetLanesByJanCodeFromCabinet(string cabinetNumber, string janCode);
        Task<List<Lane>> GetLanesByJanCodeFromCabinetRow(string cabinetNumber, string rowNumber, string janCode);
        Task<Lane> GetLaneByNumberFromCabinetRow(string cabinetNumber, string rowNumber, string number);
        Task CreateLaneFromCabinetRow(string cabinetNumber, string rowNumber, Lane lane);
        Task UpdateLaneFromCabinetRow(string cabinetNumber, string rowNumber, Lane lane);
        Task DeleteLaneFromCabinetRow(string cabinetNumber, string rowNumber, string number);
    }
}