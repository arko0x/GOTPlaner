using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GOTPlaner.Data;
using GOTPlaner.Models;
using GOTPlaner.Models.DTO;

namespace GOTPlaner.Controllers.API
{
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
        [Route("api/TouristPoints")]
        public  ActionResult<IEnumerable<TouristPointDto>> GetTouristPoints()
        {
            return _context.TouristPoints
                .Select(e => new TouristPointDto { 
                    ID = e.ID, 
                    Name = e.Name, 
                    MountainRangeId = e.MountainRangeId, 
                    APIName = e.Name + " | " + _context.MountainRanges.Where(mr => mr.MountainRangeId == e.MountainRangeId).FirstOrDefault().Name})
                .Distinct()
                .ToList();
        }

        // GET: api/TouristPoints/5
        [HttpGet("{id}")]
        [Route("api/TouristPoints/{id}")]
        public async Task<ActionResult<TouristPoint>> GetTouristPoint(int id)
        {
            var touristPoint = await _context.TouristPoints.FindAsync(id);

            if (touristPoint == null)
            {
                return NotFound();
            }

            return touristPoint;
        }

        // GET: api/TouristPointsPossibleFromPoint
        [HttpGet]
        [Route("api/TouristPointsPossibleFromPoint")]
        public async Task<IEnumerable<ToursPointInfo>> GetTouristPointsPossibleFromPoint([FromQuery(Name = "pointId")] int pointId)
        {
            var segments = await _context.Segments.Where(s => s.TouristPointA.ID == pointId || s.TouristPointB.ID == pointId).ToListAsync();
            var toursPoints = new List<ToursPointInfo>();
            foreach(var segment in segments) {
                int pointAId = segment.TouristPointAId;
                int pointBId = segment.TouristPointBId;
                if (pointAId == pointId)
                {
                    if (!toursPoints.Any(tp => tp.TouristPointDto.ID == pointAId))
                    {
                        var touristPoint = _context.TouristPoints.Where(t => t.ID == pointBId).First();
                        toursPoints.Add(new ToursPointInfo
                        {
                            TouristPointDto = new Models.DTO.TouristPointDto
                            {
                                ID = touristPoint.ID,
                                Name = touristPoint.Name,
                                MountainRangeId = touristPoint.MountainRangeId,
                                APIName = touristPoint.Name + " | " + _context.MountainRanges.Where(mr => mr.MountainRangeId == touristPoint.MountainRangeId).FirstOrDefault().Name
                            },
                            PointsToGain = segment.PointsAB
                        }); ;
                    }
                }
                else
                {
                    if (!toursPoints.Any(tp => tp.TouristPointDto.ID == pointBId))
                    {
                        var touristPoint = _context.TouristPoints.Where(t => t.ID == pointAId).First();
                        if (segment.PointsBA.HasValue)
                        {
                            toursPoints.Add(new ToursPointInfo
                            {
                                TouristPointDto = new Models.DTO.TouristPointDto
                                {
                                    ID = touristPoint.ID,
                                    Name = touristPoint.Name,
                                    MountainRangeId = touristPoint.MountainRangeId
                                },
                                PointsToGain = segment.PointsBA.Value
                            });
                        }
                    }
                }
            }

            return toursPoints;
        }

        // PUT: api/TouristPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTouristPoint(int id, TouristPoint touristPoint)
        //{
        //    if (id != touristPoint.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(touristPoint).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TouristPointExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TouristPoints
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TouristPoint>> PostTouristPoint(TouristPoint touristPoint)
        //{
        //    _context.TouristPoints.Add(touristPoint);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTouristPoint", new { id = touristPoint.ID }, touristPoint);
        //}

        //// DELETE: api/TouristPoints/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTouristPoint(int id)
        //{
        //    var touristPoint = await _context.TouristPoints.FindAsync(id);
        //    if (touristPoint == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TouristPoints.Remove(touristPoint);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TouristPointExists(int id)
        //{
        //    return _context.TouristPoints.Any(e => e.ID == id);
        //}
    }
}
