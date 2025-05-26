using Locations_Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locations_Backend.Controllers
{
    [ApiController]
    [Route("api/Locations")]
    public class LocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations
                .Include(l => l.LocalType)
                .Include(l => l.LocationClass)
                .Include(l => l.Locality)
                .Include(l => l.LocalState)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
                return NotFound();

            return location;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            try
            {
                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Id)
                return BadRequest("El ID no coincide.");

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                    return NotFound("No se encontró el registro para actualizar.");

                return StatusCode(500, "Error de concurrencia al actualizar.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var location = await _context.Locations.FindAsync(id);
                if (location == null)
                    return NotFound("No se encontró la ubicación.");

                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }

        [HttpGet("GetLocalTypes")]
        public async Task<ActionResult<IEnumerable<LocalType>>> GetLocalTypes()
        {
            return await _context.LocalTypes.ToListAsync();
        }

        [HttpGet("GetLocationClasses")]
        public async Task<ActionResult<IEnumerable<LocationClass>>> GetLocationClasses()
        {
            return await _context.LocationClasses.ToListAsync();
        }

        [HttpGet("GetLocalities")]
        public async Task<ActionResult<IEnumerable<Locality>>> GetLocalities()
        {
            return await _context.Localities.ToListAsync();
        }

        [HttpGet("GetLocalStates")]
        public async Task<ActionResult<IEnumerable<LocalState>>> GetLocalStates()
        {
            return await _context.LocalStates.ToListAsync();
        }

    }
}
