namespace Locations_Frontend.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations();
        Task<Location> GetLocation(int id);
        Task<Location> CreateLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(int id);
        Task<List<LocalType>> GetLocalTypes();
        Task<List<LocationClass>> GetLocationClasses();
        Task<List<Locality>> GetLocalities();
        Task<List<LocalState>> GetLocalStates();
    }
}
