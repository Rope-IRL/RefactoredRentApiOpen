using Microsoft.EntityFrameworkCore;
using RestfulApiTry.Persistence.Models;
using RestfulApiTry.Persistence.Models.Configurations;

namespace RestfulApiTry.Persistence
{
    public class RentDbContext: DbContext
    {
        public DbSet<LandlordModel> Landlords { get; set; }
        public DbSet<LesseeModel> Lessees { get; set; }
        public DbSet<LandlordInformationModel> LandlordInformations { get; set; }
        public DbSet<LesseeInformationModel> LesseeInformations { get; set; }
        public DbSet<FlatModel> Flats { get; set; }
        public RentDbContext(DbContextOptions<RentDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LandlordModelConfiguration());
            builder.ApplyConfiguration(new LandlordInformationModelConfiguration());
            builder.ApplyConfiguration(new LesseeModelConfiguration());
            builder.ApplyConfiguration(new LesseeInformationModelConfiguration());
            builder.ApplyConfiguration(new FlatModelConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
