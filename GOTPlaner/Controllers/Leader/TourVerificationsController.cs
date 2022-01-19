using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOTPlaner.Data;
using GOTPlaner.Models;

namespace GOTPlaner.Controllers.Leader
{
    public class TourVerificationsController : Controller
    {
        private readonly GotContext _context;

        public TourVerificationsController(GotContext context)
        {
            _context = context;
        }

        // GET: TourVerifications
        public async Task<IActionResult> Index()
        {
            var gotContext = _context.TourVerifications.Include(t => t.Status)
                .Where(t => t.TourVerificationStatusId == TourVerificationStatusId.Zgloszona ||
                t.TourVerificationStatusId == TourVerificationStatusId.DoPonownegoRozpatrzenia)
                .Where(t => t.LeaderEmail != User.Identity.Name);
            return View(await gotContext.ToListAsync());
        }

        // GET: TourVerifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourVerification = await _context.TourVerifications
                .Include(t => t.Status)
                .Include(t => t.Tour.SegmentCrosses).ThenInclude(t => t.Segment.TouristPointA)
                .Include(t => t.Tour.SegmentCrosses).ThenInclude(t => t.Segment.TouristPointB)
                .Include(t => t.Tour.SegmentCrosses).ThenInclude(t => t.Segment.ElementType)
                .Include(t => t.Leader)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tourVerification == null)
            {
                return NotFound();
            }

            int sumaPkt = 0;
            double sumaKil = 0;
            int sumaPoz = 0;
            foreach (var item in tourVerification.Tour.SegmentCrosses)
            {
                sumaKil += item.Segment.NumberOfKilometers;
                sumaPoz += item.Segment.LevelDifferenceSum;
                sumaPkt += item.Direction ? item.Segment.PointsAB : (int)item.Segment.PointsBA;
            }
            ViewBag.Points = sumaPkt;
            ViewBag.Kilometers = sumaKil;
            ViewBag.LevelDiff = sumaPoz;

            return View(tourVerification);
        }

        [HttpPost]
        public IActionResult Reject(int ID, string reason)
        {
            var verification = _context.TourVerifications.First(v => v.ID == ID);
            verification.Reason = reason;
            verification.LeaderEmail = User.Identity.Name;
            verification.VerificationDate = DateTime.Now;
            verification.TourVerificationStatusId = TourVerificationStatusId.Odrzucona;
            _context.Update(verification);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Confirm(int ID)
        {
            var verification = _context.TourVerifications.First(v => v.ID == ID);
            verification.Reason = "";
            verification.LeaderEmail = User.Identity.Name;
            verification.VerificationDate = DateTime.Now;
            verification.TourVerificationStatusId = TourVerificationStatusId.Zaakceptowana;
            _context.Update(verification);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private bool TourVerificationExists(int id)
        {
            return _context.TourVerifications.Any(e => e.ID == id);
        }
    }
}
