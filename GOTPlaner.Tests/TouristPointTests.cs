using GOTPlaner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GOTPlaner.Tests
{
    public class TouristPointTests
    {
        [Fact]
        public void TouristPointsWithSameNameAndDifferentMountainRangesShouldNotBeConsideredEqual()
        {
            var pointA = new TouristPoint
            {
                Name = "Prełuki",
                MountainRangeId = MountainRangeId.Bieszczady
            };
            var pointB = new TouristPoint
            {
                Name = "Prełuki",
                MountainRangeId = MountainRangeId.PogorzeCiechowickie
            };

            Assert.False(pointA.Equals(pointB));
        }

        [Fact]
        public void TouristPointsWithSameNameAndSameMountainRangesShouldBeConsideredEqual()
        {
            var pointA = new TouristPoint
            {
                Name = "Prełuki",
                MountainRangeId = MountainRangeId.Bieszczady
            };
            var pointB = new TouristPoint
            {
                Name = "Prełuki",
                MountainRangeId = MountainRangeId.Bieszczady
            };

            Assert.True(pointA.Equals(pointB));
        }
    }
}
