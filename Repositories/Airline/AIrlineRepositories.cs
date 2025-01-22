using AirAccess.Database;
using AirAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AirAccess.Repository
{
    public class AirlineRepositories : IAirlineRepository
    {
        private readonly AppDbContext _context;

        public AirlineRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Airline> StoreAsync(Airline request)
        {
            await _context.Airlines.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        
        public async Task DeleteAsync(Guid id)
        {
            var airline = await _context.Airlines.FindAsync(id);
            if (airline != null)
            {
                _context.Airlines.Remove(airline);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Airline>> GetAllAsync()
        {
            return await _context.Airlines.ToListAsync();
        }

        public async Task<Airline> GetByIdAsync(Guid id)
        {
            var airline = await _context.Airlines.FindAsync(id);
            return airline!;
        }

        public async Task<Airline?> UpdateAsync(Guid id, Airline request)
        {
            var airline = await _context.Airlines.FindAsync(request.Id);
            if (airline != null)
            {
                airline.AirlineName = request.AirlineName;
                airline.AirlineCode = request.AirlineCode;
                // Update other properties as needed

                _context.Airlines.Update(airline);
                await _context.SaveChangesAsync();
                return airline;
            }
            return null;
        }
    }
}
