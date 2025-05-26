using System.Net.Http.Json;

namespace Locations_Frontend.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _http;

        public LocationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Location>> GetLocations()
        {
            return await _http.GetFromJsonAsync<List<Location>>("api/Locations") ?? new();
        }

        public async Task<Location> GetLocation(int id)
        {
            return await _http.GetFromJsonAsync<Location>($"api/Locations/{id}");
        }

        public async Task<Location> CreateLocation(Location location)
        {
            var response = await _http.PostAsJsonAsync("api/Locations", location);
            return await response.Content.ReadFromJsonAsync<Location>() ?? new Location();
        }

        public async Task UpdateLocation(Location location)
        {
            await _http.PutAsJsonAsync($"api/Locations/{location.Id}", location);
        }

        public async Task DeleteLocation(int id)
        {
            await _http.DeleteAsync($"api/Locations/{id}");
        }

        public async Task<List<LocalType>> GetLocalTypes()
        {
            return await _http.GetFromJsonAsync<List<LocalType>>("api/Locations/GetLocalTypes") ?? new();
        }

        public async Task<List<LocationClass>> GetLocationClasses()
        {
            return await _http.GetFromJsonAsync<List<LocationClass>>("api/Locations/GetLocationClasses") ?? new();
        }

        public async Task<List<Locality>> GetLocalities()
        {
            return await _http.GetFromJsonAsync<List<Locality>>("api/Locations/GetLocalities") ?? new();
        }

        public async Task<List<LocalState>> GetLocalStates()
        {
            return await _http.GetFromJsonAsync<List<LocalState>>("api/Locations/GetLocalStates") ?? new();
        }

    }
}
