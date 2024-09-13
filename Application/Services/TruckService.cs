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
        private readonly IOperationLogRepository _operationLogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TruckService(
            ITruckRepository truckRepository,
            IOperationLogRepository operationLogRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _truckRepository = truckRepository;
            _operationLogRepository = operationLogRepository;
            _unitOfWork = unitOfWork;
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
            truck.State = TruckState.AwaitingFirstApproval;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _truckRepository.AddAsync(truck);

                var operationLog = new OperationLog
                {
                    OperationType = "Create",
                    AffectedEntity = "Truck",
                    AffectedEntityId = truck.Id,
                    Timestamp = DateTime.UtcNow,
                    Description = $"Added a new truck with license plate {truck.Plate}."
                };

                await _operationLogRepository.AddAsync(operationLog);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
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

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _truckRepository.UpdateAsync(truck);

                var operationLog = new OperationLog
                {
                    OperationType = "Update",
                    AffectedEntity = "Truck",
                    AffectedEntityId = truck.Id,
                    Timestamp = DateTime.UtcNow,
                    Description = $"Updated the state of the truck with license plate {truck.Plate}."
                };

                await _operationLogRepository.AddAsync(operationLog);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
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
            var truck = await _truckRepository.GetByPlateAsync(truckDto.Plate);
            if (truck == null) return;

            truck.Weight = truckDto.Weight;

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _truckRepository.UpdateAsync(truck);

                var operationLog = new OperationLog
                {
                    OperationType = "Update",
                    AffectedEntity = "Truck",
                    AffectedEntityId = truck.Id,
                    Timestamp = DateTime.UtcNow,
                    Description = $"Updated the weight of the truck with license plate {truck.Plate}."
                };

                await _operationLogRepository.AddAsync(operationLog);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
