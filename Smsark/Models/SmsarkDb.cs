
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace Smsark.Models
{
    public class SmsarkDb : DbContext
    {

        public SmsarkDb(DbContextOptions<SmsarkDb> options) : base(options)
        {

        }
        public DbSet<Apartment> apartments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<ReservationItem> reservationItems { get; set; }
        public DbSet<Bed> Beds { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.HasMany(e => e.reservations)
				.WithOne(e => e.Customer)
				.HasForeignKey(e => e.CustomerEmail);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer(@"
                           Server=LAPTOP-7A6I7DSO\SQL2022;
                           Database=soha3;
                           Trusted_Connection=True;
                           TrustServerCertificate=True;");

        }
    }
    }

