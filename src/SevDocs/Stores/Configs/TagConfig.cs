using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class TagConfig : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .HasOne(x => x.TagCategory)
            .WithMany(x => x.Tags)
            .HasForeignKey(x => x.TagCategoryId);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Tags)
            .HasForeignKey(x => x.UserId);
    }
}
