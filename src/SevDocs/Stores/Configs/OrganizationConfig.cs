using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class OrganizationConfig : IEntityTypeConfiguration<OrganizationEntity>
{
    public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Street)
            .HasMaxLength(100);

        builder.Property(x => x.ZipCode)
            .HasMaxLength(10);

        builder.Property(x => x.City)
            .HasMaxLength(100);

        builder.Property(x => x.Country)
            .HasMaxLength(100);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Organizations)
            .HasForeignKey(x => x.UserId);
    }
}
