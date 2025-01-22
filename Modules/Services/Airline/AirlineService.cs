using AirAccess.Modules.Models;
using AirAccess.Repository;

namespace AirAccess.Modules.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _repository;

        public AirlineService(IAirlineRepository repository)
        {
            _repository = repository;
        }

        public async Task<Airline> CreateAsync(Airline request)
        {
            return await _repository.StoreAsync(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Airline>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Airline?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Airline?> UpdateAsync(Guid id, Airline request)
        {
            return await _repository.UpdateAsync(id, request);
        }
    }
}
