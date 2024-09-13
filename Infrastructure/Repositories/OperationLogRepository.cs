using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class OperationLogRepository : IOperationLogRepository
    {
        private readonly AppDbContext _context;

        public OperationLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OperationLog operationLog)
        {
            _context.OperationLogs.Add(operationLog);
            await _context.SaveChangesAsync();
        }
    }
}
