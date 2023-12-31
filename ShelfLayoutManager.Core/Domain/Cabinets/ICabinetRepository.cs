﻿namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public interface ICabinetRepository : IReadBaseRepository<Cabinet>
    {
        Task<List<Cabinet>> GetAll();
        Task<Cabinet> Create(Cabinet cabinet);
        Task<Cabinet> Update(Cabinet updatedCabinet);
        Task Delete();
    }
}