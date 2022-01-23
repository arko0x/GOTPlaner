using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using GOTPlaner.Data;
using GOTPlaner.Controllers.Leader;
using GOTPlaner.Models;

namespace GOTPlaner.Tests
{
    public class VerificationTest : IDisposable
    {
        private readonly GotContext _context;

        public VerificationTest()
        {
            var options = new DbContextOptionsBuilder<GotContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new GotContext(options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void Confirm_Tour()
        {
            int id = 1;
            var con = new TourVerificationsController(_context);

            var view = con.Confirm(id, "leader@localhost");
            var tour = _context.TourVerifications.First(t => t.ID == id);

            Assert.Equal(TourVerificationStatusId.Zaakceptowana, tour.TourVerificationStatusId);
        }

        [Fact]
        public void Reject_Tour()
        {
            
            int id = 1;
            string reason = "reason";
            var con = new TourVerificationsController(_context);

            var view = con.Reject(id, reason, "leader@localhost");
            var tour = _context.TourVerifications.First(t => t.ID == id);

            Assert.Equal(TourVerificationStatusId.Odrzucona, tour.TourVerificationStatusId);
            Assert.Equal(reason, tour.Reason);

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }
    }
}
