using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public interface ILaneApplication
    {
        Task<List<Lane>> GetLanes();
        Task<List<Lane>> GetLanesByJanCode(string janCode);
        Task<List<Lane>> GetLanesByJanCodeFromCabinet(int cabinetNumber, string janCode);
        Task<List<Lane>> GetLanesByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode);
        Task<Lane> GetLaneByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number);
        Task<Lane> CreateLaneFromCabinetRow(CreateLaneCommand command);
        Task UpdateLaneFromCabinetRow(int cabinetNumber, int rowNumber, int number, Lane lane);
        Task DeleteLaneFromCabinetRow(int cabinetNumber, int rowNumber, int number);
        Task MoveDrink(MoveDrinkCommand command);
    }
}