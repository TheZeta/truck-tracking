using BlazorWasmClient.Shared.DTOs;
using System.Net.Http.Json;

namespace BlazorWasmClient.Services
{
    public class TruckService
    {
        private readonly HttpClient _httpClient;

        public TruckService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TruckDto>> GetVisibleTrucksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TruckDto>>("api/trucks/visible");
        }

        public async Task AddAsync(TruckDto truckDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/trucks", truckDto);
            response.EnsureSuccessStatusCode();
        }
    }
}
