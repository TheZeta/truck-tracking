using Core.Entities;

namespace Core.Interfaces
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetVisibleTrucksAsync();
        Task<Truck> GetByIdAsync(int id);
        Task AddAsync(Truck truck);
        Task UpdateAsync(Truck truck);
        Task DeleteAsync(int id);
    }
}
