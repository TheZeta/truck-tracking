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

        public async Task UpdateTruckStateAsync(string plate)
        {
            var response = await _httpClient.GetAsync($"api/trucks/{plate}/state");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<TruckDto>> GetTrucksForEditAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TruckDto>>("api/trucks/editable");
        }

        public async Task<TruckDto> GetByPlateAsync(string plate)
        {
            return await _httpClient.GetFromJsonAsync<TruckDto>($"api/trucks/{plate}");
        }

        public async Task UpdateAsync(TruckDto truckDto)
        {
            await _httpClient.PutAsJsonAsync($"api/trucks/{truckDto.LicensePlate}", truckDto);
        }
    }
}
