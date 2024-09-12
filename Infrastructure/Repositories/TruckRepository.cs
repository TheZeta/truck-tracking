using BlazorWasmClient.Shared.Enums;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly AppDbContext _context;

        public TruckRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Truck>> GetVisibleTrucksAsync()
        {
            return await _context.Trucks
                .Where(t => t.IsVisibleOnList)
                .ToListAsync();
        }

        public async Task<Truck> GetByIdAsync(int id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<Truck> GetByPlateAsync(string plate)
        {
            return await _context.Trucks
                .FirstOrDefaultAsync(t => t.LicensePlate.Equals(plate));
        }

        public async Task AddAsync(Truck truck)
        {
            await _context.Trucks.AddAsync(truck);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Truck truck)
        {
            _context.Trucks.Update(truck);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            if (truck != null)
            {
                _context.Trucks.Remove(truck);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Truck>> GetTrucksForEditAsync()
        {
            return await _context.Trucks
                .Where(t => t.State == TruckState.AwaitingWeighing)
                .ToListAsync();
        }
    }
}
