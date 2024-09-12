using Application.Services;
using BlazorWasmClient.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TrucksController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet("visible")]
        public async Task<ActionResult<IEnumerable<TruckDto>>> GetVisibleTrucks()
        {
            var trucks = await _truckService.GetVisibleTrucksAsync();
            return Ok(trucks);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTruck(TruckDto truckDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _truckService.AddAsync(truckDto);

            return CreatedAtAction(nameof(GetTruckById), new { id = truckDto.LicensePlate }, truckDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruckById(int id)
        {
            var truck = await _truckService.GetByIdAsync(id);
            if (truck == null)
            {
                return NotFound();
            }

            return Ok(truck);
        }

        [HttpGet("{plate}/state")]
        public async Task<IActionResult> UpdateState(string plate)
        {
            await _truckService.UpdateStateAsync(plate);

            return NoContent();
        }
    }
}
