using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirAccess.Modules.Models;

namespace AirAccess.Modules.Services
{
    public interface IAirlineService
    {
        Task<IEnumerable<Airline>> GetAllAsync();
        Task<Airline> GetByIdAsync(Guid id);
        Task<Airline> CreateAsync(Airline airline);
        Task<Airline> UpdateAsync(Guid id, Airline airline);
        Task DeleteAsync(Guid id);
    }
}

