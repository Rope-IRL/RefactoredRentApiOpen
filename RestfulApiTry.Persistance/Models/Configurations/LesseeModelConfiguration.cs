using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestfulApiTry.Persistence.Models.Configurations
{
    public class LesseeModelConfiguration: IEntityTypeConfiguration<LesseeModel>
    {
        public void Configure(EntityTypeBuilder<LesseeModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(f => f.Login);
            builder.Property(f => f.HashedPassword);
            builder.HasOne(x => x.LesseeInformationModel)
                .WithOne(x => x.LesseeModel)
                .HasForeignKey<LesseeModel>(x => x.LesseeInformationId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
