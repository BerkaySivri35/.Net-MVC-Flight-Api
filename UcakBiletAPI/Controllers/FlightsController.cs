using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UcakBiletAPI.Controllers.Models;

namespace UcakBiletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FlightsController : ControllerBase
    {
        private readonly FligthApiDatabaseContext _dbContext;

        public FlightsController(FligthApiDatabaseContext dbContext) => _dbContext = dbContext; /*Dependency Injection*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> Get()
        {
            if (_dbContext.Flight == null)
                return NotFound();
            return await _dbContext.Flight.Where(x => !x.IsDeleted).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> Get(int id)
        {
            if (_dbContext.Flight == null && _dbContext.Flight.Any(x => x.Id != id))
                return NotFound();
            return await _dbContext.Flight.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> Post(Flight flight)
        {
            _dbContext.Flight.Add(flight);
            await _dbContext.SaveChangesAsync();
            return Ok("Başarıyla eklendi!");
        }



        [HttpPut] /* DTO */
        public async Task<ActionResult<Flight>> Put(int id, Flight flight)
        {
            if(id != flight.Id)
                return BadRequest();

            _dbContext.Entry(flight).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExits(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
            
        }

        private bool FlightExits(long id)
        {
            return (_dbContext.Flight?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (_dbContext.Flight == null)
                return NotFound();

            var findFlight = await _dbContext.Flight.FindAsync(id);

            if (findFlight == null)
                return NotFound();

            _dbContext.Flight.Remove(findFlight);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
} 
