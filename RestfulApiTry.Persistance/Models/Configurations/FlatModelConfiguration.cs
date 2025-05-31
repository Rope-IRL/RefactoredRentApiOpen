using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestfulApiTry.Persistence.Models.Configurations;

public class FlatModelConfiguration : IEntityTypeConfiguration<FlatModel>
{
    public void Configure(EntityTypeBuilder<FlatModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Header).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.AverageMark);
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.NumberOfRooms);
        builder.Property(x => x.NumberOfFloors);
        builder.Property(x => x.IsBathRoomAvailable);
        builder.Property(x => x.IsWiFiAvailable);
        builder.Property(x => x.CostPerDay);
        builder.HasOne(x => x.LandlordModel)
            .WithMany(x => x.Flats)
            .HasForeignKey(x => x.LandlordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}