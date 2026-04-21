using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class DocumentConfig : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasGeneratedTsVectorColumn(
            x => x.SearchVector,
            "simple",
            x => x.TextContent)
            .HasIndex(x => x.SearchVector)
            .HasMethod("GIN");

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OriginalFileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.ConvertedName)
            .HasMaxLength(35);

        builder.Property(x => x.CoverName)
            .HasMaxLength(35);

        builder.Property(x => x.Checksum)
            .HasMaxLength(64);

        builder
            .HasOne(x => x.Folder)
            .WithMany(x => x.Documents)
            .HasForeignKey(x => x.FolderId);
    }
}
