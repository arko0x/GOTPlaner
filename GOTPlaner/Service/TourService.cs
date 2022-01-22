using GOTPlaner.Data;
using GOTPlaner.Models;
using GOTPlaner.Models.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace GOTPlaner.Service
{
    public class TourService
    {
        private GotContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public TourService(GotContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _httpContextAccessor = contextAccessor;
        }

        public void BuildTour(List<TourItemDto> tourItemDtos)
        {
            Tour tour = new Tour
            {
                CreationDate = System.DateTime.Now,
                TouristEmail = _httpContextAccessor.HttpContext.User.Identity.Name,
                BadgeTypeId = BadgeTypeId.Popularna
            };
            _context.Add<Tour>(tour);

            for (int i = 1; i < tourItemDtos.Count; i++)
            {
                TouristPoint previousTouristPoint;
                if (tourItemDtos[i - 1].OwnPoint)
                {
                    previousTouristPoint = new TouristPoint
                    {
                        ElementType = _context.ElementTypes.Where(e => e.ElementTypeId == ElementTypeId.UserType).First(),
                        ElementTypeId = ElementTypeId.UserType,
                        MountainRange = _context.MountainRanges.Where(m => m.Name.Equals(tourItemDtos[i - 1].MountainRangeName)),
                        MountainRangeId = _context.MountainRanges.Where(m => m.Name.Equals(tourItemDtos[i - 1].MountainRangeId)),
                        Name = tourItemDtos[i - 1].TouristPointName
                    };
                    _context.Add<TouristPoint>(previousTouristPoint);
                }
                else
                {
                    previousTouristPoint = _context.TouristPoints.Where(t => t.ID == tourItemDtos[i - 1].TouristPointId).First();
                }

                TouristPoint currentTouristPoint;
                if (tourItemDtos[i].OwnPoint)
                {
                    currentTouristPoint = new TouristPoint
                    {
                        ElementType = _context.ElementTypes.Where(e => e.ElementTypeId == ElementTypeId.UserType).First(),
                        ElementTypeId = ElementTypeId.UserType,
                        MountainRangeId = _context.MountainRanges.Where(m => ((int)m.MountainRangeId == tourItemDtos[i].MountainRangeId)).First().MountainRangeId,
                        Name = tourItemDtos[i].TouristPointName
                    };
                    _context.Add<TouristPoint>(currentTouristPoint);
                }
                else
                {
                    currentTouristPoint = _context.TouristPoints.Where(t => t.ID == tourItemDtos[i].TouristPointId).First();
                }

                Segment segment;
                if (tourItemDtos[i - 1].OwnPoint || tourItemDtos[i].OwnPoint)
                {
                    segment = new Segment
                    {
                        ElementType = _context.ElementTypes.Where(e => e.ElementTypeId == ElementTypeId.UserType).First(),
                        ElementTypeId = ElementTypeId.UserType,
                        LevelDifferenceSum = tourItemDtos[i].LevelDifference.Value,
                        NumberOfKilometers = tourItemDtos[i].NumberOfKilometers.Value,
                        PointsAB = tourItemDtos[i].CurrentPoints.Value,
                        TouristPointA = previousTouristPoint
                    };
                    _context.Add<Segment>(segment);
                }
                else
                {
                    segment = _context.Segments.Where(
                        s => (s.TouristPointAId == tourItemDtos[i - 1].TouristPointId && s.TouristPointBId == tourItemDtos[i].TouristPointId) ||
                            s.TouristPointBId == tourItemDtos[i - 1].TouristPointId && s.TouristPointAId == tourItemDtos[i].TouristPointId)
                        .First();
                }

                SegmentCross segmentCross = new SegmentCross
                {
                    Tour = tour,
                    Segment = segment,
                    Order = i
                };

                _context.Add(segmentCross);
            }
        }
    }
}
