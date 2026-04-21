using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class FolderTagConfig : IEntityTypeConfiguration<FolderTagEntity>
{
    public void Configure(EntityTypeBuilder<FolderTagEntity> builder)
    {
        builder.HasKey(x => new { x.FolderId, x.TagId });
    }
}
