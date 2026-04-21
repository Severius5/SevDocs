using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class FolderLinkConfig : IEntityTypeConfiguration<FolderLinkEntity>
{
    public void Configure(EntityTypeBuilder<FolderLinkEntity> builder)
    {
        builder.HasKey(x => new { x.FolderLinksId, x.FolderLinkedId });
    }
}
