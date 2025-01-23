using System.Net;
using AirAccess.Modules.Dtos.Airline;
using AirAccess.Modules.Models;
using AirAccess.Modules.Request.Airline;
using AirAccess.Modules.Services;
using KelanisCoalTerminal.Infrastructures.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirAccess.Modules.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }
        
        [HttpGet(Name = "GetAirlines")]
        [Tags("Airline")]
        [ProducesResponseType(typeof(IEnumerable<AirlineDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirlines()
        {
            var airlines = await _airlineService.GetAllAsync();
            return Ok(airlines);
        }

        [HttpPost(Name = "CreateAirline")]
        [Tags("Airline")]
        [ProducesResponseType(typeof(AirlineDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAirlineRequest request)
        {
            try
            {
                var airline = new Airline
                {
                    AirlineName = request.AirlineName,
                    AirlineCode = request.AirlineCode
                };
                var createdAirline = await _airlineService.CreateAsync(airline);
                return CreatedAtRoute("GetAirline", new { id = createdAirline.Id }, createdAirline);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateAirline")]
        [Tags("Airline")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateAirlineRequest request)
        {
            try
            {
                var data = await _airlineService.GetByIdAsync(id);
                return Ok(new ResponseBuilder<AirlineDto>()
                
                {
                    Data = new AirlineDto
                    {
                        Id = data.Id,
                        AirlineName = data.AirlineName,
                        AirlineCode = data.AirlineCode
                    },
                    StatusCode = HttpStatusCode.OK,
                    Message = "Airline updated successfully"
                }

                );
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBuilder<object>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Success = false
                });
            }
        }

        [HttpGet("{id}", Name = "GetAirline")]
        [Tags("Airline")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _airlineService.GetByIdAsync(id);
                return Ok(new ResponseBuilder<AirlineDto>()
                {
                    Data = new AirlineDto
                    {
                        Id = data.Id,
                        AirlineName = data.AirlineName,
                        AirlineCode = data.AirlineCode
                    },
                    StatusCode = HttpStatusCode.OK,
                    Message = "Airline fetched successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBuilder<object>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Success = false
                });
            }            
        }

        [HttpDelete("{id}", Name = "DeleteAirline")]
        [Tags("Airline")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _airlineService.DeleteAsync(id);
                return Ok(new ResponseBuilder<object>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Airline deleted successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBuilder<object>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Success = false
                });
            }
        }
    }
}