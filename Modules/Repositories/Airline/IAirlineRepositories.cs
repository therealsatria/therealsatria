using AirAccess.Modules.Models;

namespace AirAccess.Repository
{
    public interface IAirlineRepository
    {
        Task<IEnumerable<Airline>> GetAllAsync();
        Task<Airline> GetByIdAsync(Guid id);
        Task<Airline> StoreAsync(Airline request);
        Task DeleteAsync(Guid id);
        Task<Airline?> UpdateAsync(Guid id, Airline request);
    }
}
