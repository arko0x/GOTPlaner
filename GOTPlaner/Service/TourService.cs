using GOTPlaner.Data;
using GOTPlaner.Models;
using GOTPlaner.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
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

        public bool BuildTour(List<TourItemDto> tourItemDtos)
        {
            try
            {
                List<TouristPoint> addedTouristPoints = new List<TouristPoint>();
                Tour tour = new Tour
                {
                    CreationDate = System.DateTime.Now,
                    TouristEmail = _httpContextAccessor.HttpContext.User.Identity.Name,
                    BadgeTypeId = BadgeTypeId.Popularna
                };
                _context.Add<Tour>(tour);
                _context.SaveChanges();

                for (int i = 1; i < tourItemDtos.Count; i++)
                {
                    TouristPoint previousTouristPoint;
                    if (tourItemDtos[i - 1].OwnPoint &&
                        _context.TouristPoints
                        .Where(tp => tp.Name.Equals(tourItemDtos[i - 1].TouristPointName) &&
                        ((int)tp.MountainRangeId) == tourItemDtos[i - 1].MountainRangeId).Count() == 0)
                    {
                        previousTouristPoint = new TouristPoint
                        {
                            ElementTypeId = ElementTypeId.UserType,
                            MountainRangeId = _context.MountainRanges.Where(m => (int)m.MountainRangeId == tourItemDtos[i - 1].MountainRangeId).First().MountainRangeId,
                            Name = tourItemDtos[i - 1].TouristPointName
                        };
                        if (!addedTouristPoints.Contains(previousTouristPoint))
                        {
                            _context.Add<TouristPoint>(previousTouristPoint);
                            addedTouristPoints.Add(previousTouristPoint);
                        }
                    }
                    else
                    {
                        previousTouristPoint = _context.TouristPoints.Where(t => t.Name.Equals(tourItemDtos[i - 1].TouristPointName) && ((int)t.MountainRangeId) == tourItemDtos[i - 1].MountainRangeId).First();
                    }

                    TouristPoint currentTouristPoint;
                    if (_context.TouristPoints
                        .Where(tp => tp.Name.Equals(tourItemDtos[i].TouristPointName) &&
                        ((int)tp.MountainRangeId) == tourItemDtos[i].MountainRangeId).Count() == 0)
                    {
                        currentTouristPoint = new TouristPoint
                        {
                            ElementTypeId = ElementTypeId.UserType,
                            MountainRangeId = _context.MountainRanges.Where(m => ((int)m.MountainRangeId == tourItemDtos[i].MountainRangeId)).First().MountainRangeId,
                            Name = tourItemDtos[i].TouristPointName
                        };
                        if (!addedTouristPoints.Contains(currentTouristPoint))
                        {
                            _context.Add<TouristPoint>(currentTouristPoint);
                            addedTouristPoints.Add(currentTouristPoint);
                        }
                    }
                    else
                    {
                        currentTouristPoint = _context.TouristPoints.Where(t => t.Name.Equals(tourItemDtos[i].TouristPointName) && ((int)t.MountainRangeId) == tourItemDtos[i].MountainRangeId).First();
                    }
                    _context.SaveChanges();
                    Segment segment;
                    if (tourItemDtos[i - 1].OwnPoint || tourItemDtos[i].OwnPoint)
                    {
                        segment = new Segment
                        {
                            ElementTypeId = ElementTypeId.UserType,
                            LevelDifferenceSum = tourItemDtos[i].LevelDifference.Value,
                            NumberOfKilometers = tourItemDtos[i].NumberOfKilometers.Value,
                            PointsAB = tourItemDtos[i].CurrentPoints.Value,
                            PointsBA = null,
                            TouristPointAId = previousTouristPoint.ID,
                            TouristPointBId = currentTouristPoint.ID
                        };
                        var possiblyExistingSegment = _context.Segments.Where(s => s.TouristPointAId == currentTouristPoint.ID && s.TouristPointBId == previousTouristPoint.ID).FirstOrDefault();
                        if (possiblyExistingSegment == null)
                        {
                            _context.Update<Segment>(segment);
                        }
                        else
                        {
                            possiblyExistingSegment.PointsBA = tourItemDtos[i].CurrentPoints.Value;
                            _context.Update<Segment>(possiblyExistingSegment);
                        }
                    }
                    else
                    {
                        segment = _context.Segments.Where(
                            s => (s.TouristPointAId == tourItemDtos[i - 1].TouristPointId && s.TouristPointBId == tourItemDtos[i].TouristPointId) ||
                                s.TouristPointBId == tourItemDtos[i - 1].TouristPointId && s.TouristPointAId == tourItemDtos[i].TouristPointId)
                            .First();
                    }
                    _context.SaveChanges();

                    SegmentCross segmentCross = new SegmentCross
                    {
                        TourId = tour.ID,
                        SegmentId = segment.ID,
                        Order = i,
                        Direction = previousTouristPoint.ID == segment.TouristPointAId ? true : false
                    };

                    _context.Add(segmentCross);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                // tutaj bylaby dodana do systemu monitorujacego zdarzenia informacja o rodzaju bledu
                return false;
            }
        }
    }
}
