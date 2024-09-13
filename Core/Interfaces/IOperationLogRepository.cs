using Core.Entities;

namespace Core.Interfaces
{
    public interface IOperationLogRepository
    {
        Task AddAsync(OperationLog operationLog);
    }
}
