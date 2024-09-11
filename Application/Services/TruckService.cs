using Application.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<TruckDto>> GetVisibleTrucksAsync()
        {
            var trucks = await _truckRepository.GetVisibleTrucksAsync();
            return trucks.Select(t => new TruckDto
            {
                LicensePlate = t.LicensePlate,
                ClaimedRawMaterialWeight = t.ClaimedRawMaterialWeight,
                RawMaterial = t.RawMaterial
            }).ToList();
        }

        public async Task AddAsync(TruckDto truckDto)
        {
            var truck = new Truck
            {
                LicensePlate = truckDto.LicensePlate,
                ClaimedRawMaterialWeight = truckDto.ClaimedRawMaterialWeight,
                RawMaterial = truckDto.RawMaterial,
                FirstWeighing = 0,
                SecondWeighing = 0,
                State = Core.Enums.TruckState.AwaitingWeighing,
                IsVisibleOnList = true
            };

            await _truckRepository.AddAsync(truck);
        }

        public async Task<TruckDto> GetByIdAsync(int id)
        {
            var truck = await _truckRepository.GetByIdAsync(id);

            if (truck == null)
            {
                return null;
            }

            return new TruckDto
            {
                LicensePlate = truck.LicensePlate,
                ClaimedRawMaterialWeight = truck.ClaimedRawMaterialWeight,
                RawMaterial = truck.RawMaterial
            };
        }
    }
}
