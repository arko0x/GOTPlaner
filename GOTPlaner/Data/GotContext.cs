using GOTPlaner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GOTPlaner.Data
{
    public class GotContext : IdentityDbContext
    {
        public GotContext(DbContextOptions<GotContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BadgeType>()
                .HasIndex(bt => bt.Name)
                .IsUnique();
            modelBuilder.Entity<TourVerificationStatus>()
                .HasIndex(tvs => tvs.Name)
                .IsUnique();
            modelBuilder.Entity<Leader>()
                .HasIndex(l => l.IDCard)
                .IsUnique();
            modelBuilder.Entity<TouristPoint>()
                .HasIndex(tp => new { tp.Name, tp.MountainRangeId })
                .IsUnique();
            modelBuilder.Entity<MountainGroup>()
                .HasIndex(mg => mg.Name)
                .IsUnique();
            modelBuilder.Entity<MountainRange>()
                .HasIndex(mr => mr.Name)
                .IsUnique();

            modelBuilder.Entity<BadgeType>()
                .HasMany(bt => bt.Badges)
                .WithOne(b => b.BadgeType);
            modelBuilder.Entity<Tourist>()
                .HasMany(t => t.Badges)
                .WithOne(b => b.Tourist);
            modelBuilder.Entity<Tourist>()
                .HasMany(t => t.Tours)
                .WithOne(t => t.Tourist);
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.SegmentCrosses)
                .WithOne(sc => sc.Tour);
            modelBuilder.Entity<Tour>()
                .HasMany(t => t.TourVerifications)
                .WithOne(tv => tv.Tour);
            modelBuilder.Entity<BadgeType>()
                .HasMany(bt => bt.Tours)
                .WithOne(t => t.BadgeType);
            modelBuilder.Entity<TourVerificationStatus>()
                .HasMany(tvs => tvs.TourVerifications)
                .WithOne(tv => tv.Status);
            modelBuilder.Entity<Leader>()
                .HasMany(l => l.TourVerifications)
                .WithOne(tv => tv.Leader);
            modelBuilder.Entity<Leader>()
                .HasMany(l => l.LeaderPermissions)
                .WithOne(lp => lp.Leader);
            modelBuilder.Entity<MountainGroup>()
                .HasMany(mg => mg.LeaderPermissions)
                .WithOne(lp => lp.MountainGroup);
            modelBuilder.Entity<Segment>()
                .HasMany(s => s.SegmentCrosses)
                .WithOne(sc => sc.Segment);
            modelBuilder.Entity<Segment>()
                .HasMany(s => s.SegmentCloses)
                .WithOne(sc => sc.Segment);
            modelBuilder.Entity<TouristPoint>()
                .HasMany(t => t.SegmentsA)
                .WithOne(s => s.TouristPointA);
            modelBuilder.Entity<TouristPoint>()
                .HasMany(t => t.SegmentsB)
                .WithOne(s => s.TouristPointB);
            modelBuilder.Entity<Segment>()
                .Property(s => s.ElementTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<TouristPoint>()
                .Property(t => t.ElementTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<ElementType>()
                .Property(e => e.ElementTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<ElementType>()
                .HasData(
                    Enum.GetValues(typeof(ElementTypeId))
                    .Cast<ElementTypeId>()
                    .Select(e => new ElementType
                    {
                        ElementTypeId = e,
                        Name = e.ToString()
                    }));
            modelBuilder.Entity<Badge>()
                .Property(b => b.BadgeTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<BadgeType>()
                .Property(bt => bt.BadgeTypeId)
                .HasConversion<int>();
            modelBuilder.Entity<BadgeType>().HasData(
                Enum.GetValues(typeof(BadgeTypeId))
                .Cast<BadgeTypeId>()
                .Select(e => new BadgeType()
                {
                    BadgeTypeId = e,
                    Name = e.ToString()
                }));
            modelBuilder.Entity<LeaderPermission>()
                .Property(l => l.MountainGroupId)
                .HasConversion<int>();
            modelBuilder.Entity<MountainGroup>()
                .Property(mr => mr.MountainGroupId)
                .HasConversion<int>();
            modelBuilder.Entity<MountainGroup>().HasData(
                Enum.GetValues(typeof(MountainGroupId))
                .Cast<MountainGroupId>()
                .Select(e => new MountainGroup()
                {
                    MountainGroupId = e,
                    Name = e.ToString()
                }));
            modelBuilder.Entity<TouristPoint>()
                .Property(t => t.MountainRangeId)
                .HasConversion<int>();
            modelBuilder.Entity<MountainRange>()
                .Property(m => m.MountainRangeId)
                .HasConversion<int>();
            modelBuilder.Entity<MountainRange>().HasData(
                Enum.GetValues(typeof(MountainRangeId))
                .Cast<MountainRangeId>()
                .Select(e => new MountainRange()
                {
                    MountainRangeId = e,
                    Name = e.ToString()
                }));
            modelBuilder.Entity<TourVerification>()
                .Property(t => t.TourVerificationStatusId)
                .HasConversion<int>();
            modelBuilder.Entity<TourVerificationStatus>()
                .Property(t => t.TourVerificationStatusId)
                .HasConversion<int>();
            modelBuilder.Entity<TourVerificationStatus>().HasData(
                Enum.GetValues(typeof(TourVerificationStatusId))
                .Cast<TourVerificationStatusId>()
                .Select(e => new TourVerificationStatus()
                {
                    TourVerificationStatusId = e,
                    Name = e.ToString()
                }));

            modelBuilder.Entity<Segment>()
                .HasIndex(s => new { s.TouristPointAId, s.TouristPointBId})
                .IsUnique();

            // data initialization
            modelBuilder.Entity<Tourist>()
                .HasData(
                new Tourist
                {
                    Email = "tourist@localhost",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Parse("1998-01-01"),
                    Disability = false
                });

            modelBuilder.Entity<Leader>()
                .HasData(
                new Leader
                {
                    Email = "leader@localhost",
                    FirstName = "Michał",
                    LastName = "Głuś",
                    BirthDate = DateTime.Parse("1978-01-01"),
                    Disability = false,
                    IDCard = 112
                },
                new Leader
                {
                    Email = "leader2@localhost",
                    FirstName = "Kamil",
                    LastName = "Zdun",
                    BirthDate = DateTime.Parse("1978-01-01"),
                    Disability = false,
                    IDCard = 997
                });

            modelBuilder.Entity<TouristPoint>()
                .HasData(
                new TouristPoint
                {
                    ID = 1,
                    Name = "Dyszowa",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                },
                new TouristPoint
                {
                    ID = 2,
                    Name = "Prełuki",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                },
                new TouristPoint
                {
                    ID = 3,
                    Name = "Mików",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                },
                new TouristPoint
                {
                    ID = 4,
                    Name = "Jaworne",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                },
                new TouristPoint
                {
                    ID = 5,
                    Name = "Rabia Skała",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                },
                new TouristPoint
                {
                    ID = 6,
                    Name = "Chmiel",
                    MountainRangeId = MountainRangeId.Bieszczady,
                    ElementTypeId = ElementTypeId.SystemType,
                }
                );

            modelBuilder.Entity<Segment>()
                .HasData(
                new Segment
                {
                    ID = 1,
                    TouristPointAId = 1,
                    TouristPointBId = 2,
                    PointsAB = 7,
                    PointsBA = 8,
                    LevelDifferenceSum = 435,
                    NumberOfKilometers = 4.1,
                    ElementTypeId= ElementTypeId.SystemType
                },
                new Segment
                {
                    ID = 2,
                    TouristPointAId = 2,
                    TouristPointBId = 3,
                    PointsAB = 5,
                    LevelDifferenceSum = 212,
                    NumberOfKilometers = 2.4,
                    ElementTypeId = ElementTypeId.SystemType
                },
                new Segment
                {
                    ID = 3,
                    TouristPointAId = 3,
                    TouristPointBId = 4,
                    PointsAB = 5,
                    PointsBA = 4,
                    LevelDifferenceSum = 56,
                    NumberOfKilometers = 3.1,
                    ElementTypeId = ElementTypeId.SystemType
                },
                new Segment
                {
                    ID = 4,
                    TouristPointAId = 4,
                    TouristPointBId = 5,
                    PointsAB = 1,
                    PointsBA = 1,
                    LevelDifferenceSum = 24,
                    NumberOfKilometers = 1.6,
                    ElementTypeId = ElementTypeId.SystemType
                },
                new Segment
                {
                    ID = 5,
                    TouristPointAId = 2,
                    TouristPointBId = 6,
                    PointsAB = 8,
                    PointsBA = 8,
                    LevelDifferenceSum = 111,
                    NumberOfKilometers = 6.0,
                    ElementTypeId = ElementTypeId.SystemType
                },
                new Segment
                {
                    ID = 6,
                    TouristPointAId = 6,
                    TouristPointBId = 5,
                    PointsAB = 12,
                    PointsBA = 11,
                    LevelDifferenceSum = 256,
                    NumberOfKilometers = 5.3,
                    ElementTypeId = ElementTypeId.SystemType
                }
                );

            modelBuilder.Entity<Tour>()
                .HasData(
                new Tour
                {
                    ID = 1,
                    CreationDate = DateTime.Now.AddMonths(-3).Date,
                    StartDate = DateTime.Now.AddDays(-85).AddHours(-2).AddMinutes(13),
                    EndDate = DateTime.Now.AddDays(-85).AddHours(3),
                    BadgeTypeId = BadgeTypeId.Popularna,
                    TouristEmail = "tourist@localhost"
                }
                );

            modelBuilder.Entity<SegmentCross>()
                .HasData(
                new SegmentCross
                {
                    ID = 1,
                    TourId = 1,
                    SegmentId = 1,
                    Order = 1,
                    CrossDate = DateTime.Now.AddDays(-85).AddHours(-1),
                    Direction = true,
                    ImageName = "preluki.jpg"
                },
                new SegmentCross
                {
                    ID = 2,
                    TourId = 1,
                    SegmentId = 2,
                    Order = 2,
                    CrossDate = DateTime.Now.AddDays(-85).AddMinutes(12),
                    Direction = true,
                    ImageName = "mikow.jpg"
                },
                new SegmentCross
                {
                    ID = 3,
                    TourId = 1,
                    SegmentId = 3,
                    Order = 3,
                    CrossDate = DateTime.Now.AddDays(-85).AddHours(1).AddMinutes(21),
                    Direction = true,
                    ImageName = "jaworne.jpg"
                },
                new SegmentCross
                {
                    ID = 4,
                    TourId = 1,
                    SegmentId = 4,
                    Order = 4,
                    CrossDate = DateTime.Now.AddDays(-85).AddHours(3),
                    Direction = true,
                    ImageName = "rabia.jpg"
                }
                );

            modelBuilder.Entity<TourVerification>()
                .HasData(
                new TourVerification
                {
                    ID = 1,
                    TourId = 1,
                    LeaderEmail = null,
                    TourVerificationStatusId = TourVerificationStatusId.Zgloszona
                }
                );
        }

        // entities
        public DbSet<Badge> Badges { get; set; }
        public DbSet<BadgeType> BadgeTypes { get; set; }
        public DbSet<CloseSegment> CloseSegments { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<LeaderPermission> LeaderPermissions { get; set; }
        public DbSet<MountainGroup> MountainGroups { get; set; }
        public DbSet<MountainRange> MountainRanges { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<SegmentCross> SegmentCrosses { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<TouristPoint> TouristPoints { get; set; }
        public DbSet<TourVerification> TourVerifications { get; set; }
        public DbSet<TourVerificationStatus> TourVerificationStatuses { get; set; }
    }
}