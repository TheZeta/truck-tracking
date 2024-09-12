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

            //return CreatedAtAction(nameof(GetTruckById), new { plate = truckDto.LicensePlate }, truckDto);
            return Ok();
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTruckById(int id)
        //{
        //    var truck = await _truckService.GetByIdAsync(id);
        //    if (truck == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(truck);
        //}

        [HttpGet("{plate}/state")]
        public async Task<IActionResult> UpdateState(string plate)
        {
            await _truckService.UpdateStateAsync(plate);

            return NoContent();
        }

        [HttpGet("editable")]
        public async Task<IActionResult> GetTrucksForEditAsync()
        {
            var trucks = await _truckService.GetTrucksForEditAsync();
            return Ok(trucks);
        }

        [HttpGet("{plate}")]
        public async Task<IActionResult> GetByPlateAsync(string plate)
        {
            var trucks = await _truckService.GetByPlateAsync(plate);
            return Ok(trucks);
        }

        [HttpPut("{plate}")]
        public async Task<IActionResult> UpdateAsync(string plate, [FromBody] TruckDto truckDto)
        {
            await _truckService.UpdateAsync(truckDto);

            return NoContent(); // 204 No Content response to indicate successful update
        }
    }
}
