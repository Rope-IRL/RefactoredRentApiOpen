using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestfulApiTry.Persistence.Models.Configurations
{
    public class LandlordInformationModelConfiguration: IEntityTypeConfiguration<LandlordInformationModel>
    {
        public void Configure(EntityTypeBuilder<LandlordInformationModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.Property(x => x.Age);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.Score).HasPrecision(3,1).HasDefaultValue(0);
            builder.HasOne(x => x.LandlordModel).WithOne(x => x.LandlordInformationModel)
                .HasForeignKey<LandlordInformationModel>(x => x.LandlordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
