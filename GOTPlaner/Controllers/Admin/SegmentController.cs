using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOTPlaner.Data;
using GOTPlaner.Models;
using GOTPlaner.ViewModels;

namespace GOTPlaner.Controllers.Admin
{
    public class SegmentController : Controller
    {
        private readonly GotContext _context;

        public SegmentController(GotContext context)
        {
            _context = context;
        }

        // GET: Segment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Segments.ToListAsync());
        }

        // GET: Segment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // GET: Segment/Create
        public IActionResult Create()
        {
            CreateSegmentViewModel model = new CreateSegmentViewModel
            {
                MountainRanges = _context.MountainRanges.ToList()
            };
            return View(model);
        }

        // POST: Segment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSegmentViewModel createSegmentViewModel)
        {
            if (ModelState.IsValid)
            {
                TouristPoint touristPointA = _context.TouristPoints.Where(e => e.Name.Equals(createSegmentViewModel.PointA) && e.MountainRange.MountainRangeId == createSegmentViewModel.MountainRangeAId).FirstOrDefault();
                TouristPoint touristPointB = _context.TouristPoints.Where(e => e.Name.Equals(createSegmentViewModel.PointB) && e.MountainRange.MountainRangeId == createSegmentViewModel.MountainRangeBId).FirstOrDefault();
                ElementType elementType = _context.ElementTypes.Where(e => e.ElementTypeId == ElementTypeId.SystemType).First();
                ElementTypeId elementTypeId = ElementTypeId.SystemType;
                MountainRange firstMountainRange = _context.MountainRanges.Where(e => e.MountainRangeId == createSegmentViewModel.MountainRangeAId).First();
                MountainRange secondMountainRange = _context.MountainRanges.Where(e => e.MountainRangeId == createSegmentViewModel.MountainRangeBId).First();
                if (touristPointA == null && touristPointB == null)
                {
                    touristPointA = new TouristPoint
                    {
                        Name = createSegmentViewModel.PointA,
                        MountainRange = firstMountainRange,
                        MountainRangeId = firstMountainRange.MountainRangeId,
                        ElementType = elementType,
                        ElementTypeId = elementTypeId
                    };
                    _context.Add(touristPointA);
                    touristPointB = new TouristPoint
                    {
                        Name = createSegmentViewModel.PointB,
                        MountainRange = secondMountainRange,
                        MountainRangeId = secondMountainRange.MountainRangeId,
                        ElementType = elementType,
                        ElementTypeId = elementTypeId
                    };
                    _context.Add(touristPointB);
                }
                else if (touristPointA == null)
                {
                    touristPointA = new TouristPoint
                    {
                        Name = createSegmentViewModel.PointA,
                        MountainRange = firstMountainRange,
                        MountainRangeId = firstMountainRange.MountainRangeId,
                        ElementType = elementType,
                        ElementTypeId = elementTypeId
                    };
                    _context.Add(touristPointA);
                }
                else if (touristPointB == null)
                {
                    touristPointB = new TouristPoint
                    {
                        Name = createSegmentViewModel.PointB,
                        MountainRange = secondMountainRange,
                        MountainRangeId = secondMountainRange.MountainRangeId,
                        ElementType = elementType,
                        ElementTypeId = elementTypeId
                    };
                    _context.Add(touristPointB);
                }
                else
                {
                    var segm = _context.Segments.Where(
                        s => (s.TouristPointA.Name.Equals(createSegmentViewModel.PointA) && s.TouristPointB.Name.Equals(createSegmentViewModel.PointB)) ||
                              s.TouristPointB.Name.Equals(createSegmentViewModel.PointA) && s.TouristPointA.Name.Equals(createSegmentViewModel.PointB)).FirstOrDefault();
                    if (segm != null)
                    {
                        createSegmentViewModel.IsSegmentAlreadyInASystem = true;
                        createSegmentViewModel.MountainRanges = _context.MountainRanges.ToList();
                        return View(createSegmentViewModel);
                    }
                }
                var segment = new Segment
                {
                    TouristPointA = touristPointA,
                    TouristPointB = touristPointB,
                    PointsAB = createSegmentViewModel.PointsAB,
                    PointsBA = createSegmentViewModel.PointsBA,
                    LevelDifferenceSum = createSegmentViewModel.LevelDifferenceSum,
                    NumberOfKilometers = createSegmentViewModel.NumberOfKilometers,
                    ElementTypeId = elementTypeId,
                    ElementType = elementType
                };
                _context.Add(segment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            createSegmentViewModel.MountainRanges = _context.MountainRanges.ToList();
            createSegmentViewModel.IsSegmentAlreadyInASystem = false;
            return View(createSegmentViewModel);
        }

        // GET: Segment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments.FindAsync(id);
            if (segment == null)
            {
                return NotFound();
            }
            return View(segment);
        }

        // POST: Segment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PointsAB,PointsBA,LevelDifferenceSum,NumberOfKilometers,ElementTypeId")] Segment segment)
        {
            if (id != segment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(segment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegmentExists(segment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(segment);
        }

        // GET: Segment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // POST: Segment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var segment = await _context.Segments.FindAsync(id);
            _context.Segments.Remove(segment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SegmentExists(int id)
        {
            return _context.Segments.Any(e => e.ID == id);
        }
    }
}
