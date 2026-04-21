using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class TagCategoryConfig : IEntityTypeConfiguration<TagCategoryEntity>
{
    public void Configure(EntityTypeBuilder<TagCategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Color)
            .HasMaxLength(9);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.TagCategories)
            .HasForeignKey(x => x.UserId);
    }
}
