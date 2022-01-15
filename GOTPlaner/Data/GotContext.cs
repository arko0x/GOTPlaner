using GOTPlaner.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GOTPlaner.Data
{
    public class GotContext : DbContext
    {
        public GotContext(DbContextOptions<GotContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .HasIndex(tp => tp.Name)
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
            modelBuilder.Entity<Segment>()
                .Property(s => s.SegmentTypeId)
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
