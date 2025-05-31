using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RestfulApiTry.Persistence.Models.Configurations
{
    public class LandlordModelConfiguration: IEntityTypeConfiguration<LandlordModel>
    {
        public void Configure(EntityTypeBuilder<LandlordModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(f => f.Login);
            builder.Property(f => f.HashedPassword);
            builder.HasOne(x => x.LandlordInformationModel)
                .WithOne(x => x.LandlordModel)
                .HasForeignKey<LandlordModel>(x => x.LandlordInformationId)
                .OnDelete(DeleteBehavior.SetNull);
            
        }
    }
}
