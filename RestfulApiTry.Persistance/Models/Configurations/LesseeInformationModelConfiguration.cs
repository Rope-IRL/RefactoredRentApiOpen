using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestfulApiTry.Persistence.Models.Configurations;

public class LesseeInformationModelConfiguration: IEntityTypeConfiguration<LesseeInformationModel>
{
    public void Configure(EntityTypeBuilder<LesseeInformationModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(20);
        builder.Property(x => x.Surname).HasMaxLength(25);
        builder.Property(x => x.Age);
        builder.Property(x => x.PhoneNumber).HasMaxLength(15);
        builder.Property(x => x.Score).HasPrecision(3,1).HasDefaultValue(0);
        builder.HasOne(x => x.LesseeModel).WithOne(x => x.LesseeInformationModel)
            .HasForeignKey<LesseeInformationModel>(x => x.LesseeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}