using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VeloCity.Models;
using VeloCity.Models.Enums;

namespace VeloCity.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Station> Stations { get; set; }
        
        public DbSet<Bike> Bikes { get; set; }
        
        public DbSet<BikeType> BikeTypes { get; set; }
        
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole("Admin"),
                    new IdentityRole("Renter")
                );

            builder.Entity<BikeType>()
                .HasData(
                    new BikeType { Id = 1, Name = nameof(BikeType.Classic), PricePerMinute = 0.10d },
                    new BikeType { Id = 2, Name = nameof(BikeType.Road), PricePerMinute = 0.20d },
                    new BikeType { Id = 3, Name = nameof(BikeType.Mountain), PricePerMinute = 0.30d },
                    new BikeType { Id = 4, Name = nameof(BikeType.Electric), PricePerMinute = 0.40d });
            builder.Entity<Station>()
                .HasData(
                    new Station { Id = 1, Name = "Младежки културен център", Capacity = 10, Latitude = 42.496335, Longitude = 27.465771 },
                    new Station { Id = 2, Name = "Парк Славейков", Capacity = 10, Latitude = 42.520085, Longitude = 27.451919 },
                    new Station { Id = 3, Name = "Морска Гара", Capacity = 10, Latitude = 42.488880, Longitude = 27.480485 },
                    new Station { Id = 4, Name = "Пантеон", Capacity = 10, Latitude = 42.501440, Longitude = 27.482110 },
                    new Station { Id = 5, Name = "Морско Казино", Capacity = 10, Latitude = 42.494916, Longitude = 27.482633 }
                );
            builder.Entity<Bike>()
                .HasData(
                    new Bike { Id = 1, BikeTypeId = 1, Status = BikeStatus.Available, ParkedAtId = 1 },
                    new Bike { Id = 2, BikeTypeId = 2, Status = BikeStatus.Available, ParkedAtId = 1 },
                    new Bike { Id = 3, BikeTypeId = 3, Status = BikeStatus.Available, ParkedAtId = 2 },
                    new Bike { Id = 4, BikeTypeId = 4, Status = BikeStatus.Available, ParkedAtId = 2 },
                    new Bike { Id = 5, BikeTypeId = 1, Status = BikeStatus.Available, ParkedAtId = 3 },
                    new Bike { Id = 6, BikeTypeId = 2, Status = BikeStatus.Available, ParkedAtId = 3 },
                    new Bike { Id = 7, BikeTypeId = 3, Status = BikeStatus.Available, ParkedAtId = 3 },
                    new Bike { Id = 8, BikeTypeId = 3, Status = BikeStatus.Available, ParkedAtId = 3 },
                    new Bike { Id = 9, BikeTypeId = 4, Status = BikeStatus.Available, ParkedAtId = 4 },
                    new Bike { Id = 10, BikeTypeId = 2, Status = BikeStatus.Available, ParkedAtId = 4 },
                    new Bike { Id = 11, BikeTypeId = 3, Status = BikeStatus.Available, ParkedAtId = 5 },
                    new Bike { Id = 12, BikeTypeId = 1, Status = BikeStatus.Available, ParkedAtId = 5 }
                );
        }
    }
}