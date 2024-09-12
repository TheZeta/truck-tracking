using Application.DTOs;

namespace Application.Services
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckDto>> GetVisibleTrucksAsync();
        Task AddAsync(TruckDto truckDto);
        Task<TruckDto> GetByIdAsync(int id);
        Task UpdateStateAsync(string plate);
    }
}
