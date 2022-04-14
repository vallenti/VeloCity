#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeloCity.Data;
using VeloCity.Dtos;
using VeloCity.Models;
using VeloCity.RequestModels;

namespace VeloCity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : BaseAppController
    {
        public TripsController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
            : base(context, userManager)
        {
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return Ok((await _context.Trips
                    .Include(t => t.User)
                    .Include(t => t.Bike.BikeType)
                    .Include(t => t.Bike.ParkedAt)
                .ToListAsync())
                .Select(t => new TripDto(t)));
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, Trip trip)
        {
            if (id != trip.Id)
            {
                return BadRequest();
            }

            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
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

        // POST: api/Trips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("start")]
        public async Task<ActionResult<Trip>> StartTrip([FromBody] TripCreateRequest request)
        {
            var bike = this._context.Bikes.Find(request.BikeCode);
            var trip = new Trip(this.CurrentUserId, bike);
            trip.Begin();
            _context.Trips.Add(trip);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var t= ex.ToString(); ;
            }

            return CreatedAtAction("GetTrip", new { id = trip.Id }, trip);
        }

        [HttpPost("end")]
        public async Task<IActionResult> EndTrip()
        {
            var trip = await _context.Trips
                .Include(t => t.Bike)
                .Where(t => t.UserId == this.CurrentUserId && !t.IsFinished)
                .SingleAsync();

            trip.Finish();

            _context.Entry(trip).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }
    }
}
