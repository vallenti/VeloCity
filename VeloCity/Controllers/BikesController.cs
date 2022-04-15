#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeloCity.Data;
using VeloCity.Dtos;
using VeloCity.Extensions;
using VeloCity.Models;
using VeloCity.Models.Enums;
using VeloCity.RequestModels;

namespace VeloCity.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : BaseAppController
    {
        public BikesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
            : base(context, userManager)
        {
        }

        // GET: api/Bikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeDto>>> GetBikes()
        {
            return Ok((await _context.Bikes
                .Include(b => b.BikeType)
                .Include(b => b.ParkedAt)
                .ToListAsync())
                .Select(bike => new BikeDto(bike)));
        }

        [HttpGet("statuses")]
        public IEnumerable<(int id, string name)> GetBikeStatuses()
        {
            return new List<(int id, string name)>()
            {
                (id: ((int)BikeStatus.Available), name: BikeStatus.Available.ToBikeStatusString()),
                (id: ((int)BikeStatus.Service), name: BikeStatus.Service.ToBikeStatusString())
            };
        }

        [HttpGet("types")]
        public IEnumerable<(int id, string name)> GetBikeTypes()
        {
            return new List<(int id, string name)>()
            {
                (id: BikeType.Classic, name: BikeType.Classic.ToBikeTypeString()),
                (id: BikeType.Road, name: BikeType.Road.ToBikeTypeString()),
                (id: BikeType.Mountain, name: BikeType.Mountain.ToBikeTypeString()),
                (id: BikeType.Electric, name: BikeType.Electric.ToBikeTypeString())
            };
        }

        // GET: api/Bikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bike>> GetBike(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            return bike;
        }

        [HttpGet("service/{id}")]
        public async Task<IActionResult> ServiceBike(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            bike.Service();
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("available/{id}")]
        public async Task<IActionResult> MakeBikeAvailable(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            bike.Park(bike.LastParkedAt ?? 1);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Bikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBike(int id, Bike bike)
        {
            if (id != bike.Id)
            {
                return BadRequest();
            }

            _context.Entry(bike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bike>> PostBike([FromBody] BikeCreateRequest request)
        {
            var bike = new Bike(request);
            _context.Bikes.Add(bike);
            try { await _context.SaveChangesAsync(); }
            catch(Exception ex)
            {
                var x = ex;
            }
            

            return CreatedAtAction("GetBike", new { id = bike.Id }, bike);
        }

        // DELETE: api/Bikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBike(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BikeExists(int id)
        {
            return _context.Bikes.Any(e => e.Id == id);
        }
    }
}
