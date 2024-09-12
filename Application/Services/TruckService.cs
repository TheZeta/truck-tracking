using AutoMapper;
using BlazorWasmClient.Shared.DTOs;
using BlazorWasmClient.Shared.Enums;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public TruckService(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TruckDto>> GetVisibleTrucksAsync()
        {
            var trucks = await _truckRepository.GetVisibleTrucksAsync();
            return _mapper.Map<IEnumerable<TruckDto>>(trucks);
        }

        public async Task AddAsync(TruckDto truckDto)
        {
            var truck = _mapper.Map<Truck>(truckDto);
            truck.FirstWeighing = 0;
            truck.SecondWeighing = 0;
            truck.State = TruckState.AwaitingFirstApproval;
            truck.IsVisibleOnList = true;

            await _truckRepository.AddAsync(truck);
        }

        public async Task<TruckDto> GetByIdAsync(int id)
        {
            var truck = await _truckRepository.GetByIdAsync(id);

            if (truck == null) return null;

            return _mapper.Map<TruckDto>(truck);
        }

        public async Task UpdateStateAsync(string plate)
        {
            var truck = await _truckRepository.GetByPlateAsync(plate);
            if (truck == null) return;

            truck.Handle();
            await _truckRepository.UpdateAsync(truck);
        }

        public async Task<IEnumerable<TruckDto>> GetTrucksForEditAsync()
        {
            var trucks = await _truckRepository.GetTrucksForEditAsync();
            return _mapper.Map<IEnumerable<TruckDto>>(trucks);
        }

        public async Task<TruckDto> GetByPlateAsync(string plate)
        {
            var truck = await _truckRepository.GetByPlateAsync(plate);
            if (truck == null) return null;

            return _mapper.Map<TruckDto>(truck);
        }

        public async Task UpdateAsync(TruckDto truckDto)
        {
            var truck = await _truckRepository.GetByPlateAsync(truckDto.LicensePlate);
            if (truck == null) return;

            truck.ClaimedRawMaterialWeight = truckDto.ClaimedRawMaterialWeight;
            await _truckRepository.UpdateAsync(truck);
        }
    }
}
