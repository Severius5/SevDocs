using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SevDocs.Stores.Configs;

public class FolderConfig : IEntityTypeConfiguration<FolderEntity>
{
    public void Configure(EntityTypeBuilder<FolderEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasGeneratedTsVectorColumn(
            x => x.SearchVector,
            "simple",
            x => new { x.Title, x.Notes })
            .HasIndex(x => x.SearchVector)
            .HasMethod("GIN");

        builder.Property(x => x.Id)
            .HasValueGenerator<UlidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.IdHash)
            .HasMaxLength(32)
            .HasValueGenerator<Md5HashValueGenerator>()
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.CreateDate)
            .IsRequired();

        builder.Property(x => x.UpdateDate)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Folders)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.SenderPerson)
            .WithMany()
            .HasForeignKey(x => x.SenderPersonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.ReceiverPerson)
            .WithMany()
            .HasForeignKey(x => x.ReceiverPersonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Equipment)
            .WithMany()
            .HasForeignKey(x => x.EquipmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.SenderOrganization)
            .WithMany()
            .HasForeignKey(x => x.SenderOrganizationId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.ReceiverOrganization)
            .WithMany(x => x.Folders)
            .HasForeignKey(x => x.ReceiverOrganizationId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
