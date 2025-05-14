using System.Data.Entity;

namespace EventEasePart2.Models
{
    public partial class EventEasyDBContext : DbContext
    {
        public EventEasyDBContext()
            : base("name=EventEasyDBContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Event → Venue
            modelBuilder.Entity<Event>()
                .HasOptional(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .WillCascadeOnDelete(false);

            // Booking → Event
            modelBuilder.Entity<Booking>()
                .HasRequired(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .WillCascadeOnDelete(false);

            // Booking → Venue
            modelBuilder.Entity<Booking>()
                .HasRequired(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueId)
                .WillCascadeOnDelete(false);
        }
    }
}
