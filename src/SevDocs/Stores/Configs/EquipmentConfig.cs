using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class EquipmentConfig : IEntityTypeConfiguration<EquipmentEntity>
{
    public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Equipments)
            .HasForeignKey(x => x.UserId);
    }
}
