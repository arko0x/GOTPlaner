using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GOTPlaner.Data;
using GOTPlaner.Models;

namespace GOTPlaner.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristPointsController : ControllerBase
    {
        private readonly GotContext _context;

        public TouristPointsController(GotContext context)
        {
            _context = context;
        }

        // GET: api/TouristPoints
        [HttpGet]
        public  ActionResult<IEnumerable<TouristPoint>> GetTouristPoints()
        {
            var touristPoints = new List<TouristPoint>();
            touristPoints.Add(new TouristPoint
            {
                ID = 1,
                Name = "BLABLABLA",
                ElementType = new ElementType { ElementTypeId = ElementTypeId.SystemType, Name = "Systemowy" }
            });
            touristPoints.Add(new TouristPoint
            {
                ID = 1,
                Name = "BLABLABLA",
                ElementType = new ElementType { ElementTypeId = ElementTypeId.SystemType, Name = "Systemowy" }
            });
            return  touristPoints;
            //return await _context.TouristPoints.ToListAsync();
        }

        // GET: api/TouristPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristPoint>> GetTouristPoint(int id)
        {
            var touristPoint = await _context.TouristPoints.FindAsync(id);

            if (touristPoint == null)
            {
                return NotFound();
            }

            return touristPoint;
        }

        // PUT: api/TouristPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTouristPoint(int id, TouristPoint touristPoint)
        {
            if (id != touristPoint.ID)
            {
                return BadRequest();
            }

            _context.Entry(touristPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristPointExists(id))
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

        // POST: api/TouristPoints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TouristPoint>> PostTouristPoint(TouristPoint touristPoint)
        {
            _context.TouristPoints.Add(touristPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTouristPoint", new { id = touristPoint.ID }, touristPoint);
        }

        // DELETE: api/TouristPoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTouristPoint(int id)
        {
            var touristPoint = await _context.TouristPoints.FindAsync(id);
            if (touristPoint == null)
            {
                return NotFound();
            }

            _context.TouristPoints.Remove(touristPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TouristPointExists(int id)
        {
            return _context.TouristPoints.Any(e => e.ID == id);
        }
    }
}
