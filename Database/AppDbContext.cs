using AirAccess.Modules.Models;
using Microsoft.EntityFrameworkCore;

namespace AirAccess.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define your DbSets (tables) here
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your entity mappings here
            // modelBuilder.Entity<Airline>().ToTable("Airlines");
            // modelBuilder.Entity<Airport>().ToTable("Airports");
            // modelBuilder.Entity<Flight>().ToTable("Flights");
            // modelBuilder.Entity<Passenger>().ToTable("Passengers");
            // modelBuilder.Entity<Seat>().ToTable("Seats");
            // modelBuilder.Entity<Ticket>().ToTable("Tickets");
            // modelBuilder.Entity<Booking>().ToTable("Bookings");
            // modelBuilder.Entity<Payment>().ToTable("Payments");
            // modelBuilder.Entity<FlightRoute>().ToTable("FlightRoutes");

            // Configure relationships
            modelBuilder.Entity<FlightRoute>()
                .HasOne(fr => fr.OriginAirport)
                .WithMany(a => a.OriginatingRoutes)
                .HasForeignKey(fr => fr.OriginAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<FlightRoute>()
                .HasOne(fr => fr.DestinationAirport)
                .WithMany(a => a.DestinationRoutes)
                .HasForeignKey(fr => fr.DestinationAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.FlightRoute)
                .WithMany(fr => fr.Flights)
                .HasForeignKey(f => f.FlightRouteId);    

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airline)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirlineId);            
            
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Flight)
                .WithMany(f => f.Seats)
                .HasForeignKey(s => s.FlightId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SeatId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Booking)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BookingId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Passenger)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PassengerId);

            
            


            // Additional configurations if needed
            // modelBuilder.Entity<YourEntity>().Property(e => e.PropertyName).HasColumnName("ColumnName");
        }
    }
}