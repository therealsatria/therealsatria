using AirAccess.Models;

namespace AirAccess.Repository
{
    public interface IAirlineRepository
    {
        Task<List<Airline>> GetAllAsync();
        Task<Airline> GetByIdAsync(Guid id);
        Task<Airline> StoreAsync(Airline request);
        Task<Airline> UpdateAsync(Airline request);
        Task DeleteAsync(Guid id);
    }
}
