using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SevDocs.Stores.Configs;

namespace SevDocs.Stores;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, AppRole, Ulid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(b =>
        {
            b.Property(x => x.Id)
                .HasValueGenerator<UlidValueGenerator>()
                .ValueGeneratedOnAdd();

            b.Property(p => p.FirstName)
                .HasMaxLength(125);

            b.Property(p => p.LastName)
                .HasMaxLength(125);
        });

        builder.Entity<AppRole>(b =>
        {
            b.Property(x => x.Id)
                .HasValueGenerator<UlidValueGenerator>()
                .ValueGeneratedOnAdd();
        });

        builder.ApplyConfiguration(new ContactConfig());
        builder.ApplyConfiguration(new DocumentConfig());
        builder.ApplyConfiguration(new EquipmentConfig());
        builder.ApplyConfiguration(new FolderConfig());
        builder.ApplyConfiguration(new FolderLinkConfig());
        builder.ApplyConfiguration(new FolderTagConfig());
        builder.ApplyConfiguration(new OrganizationConfig());
        builder.ApplyConfiguration(new PersonConfig());
        builder.ApplyConfiguration(new TagCategoryConfig());
        builder.ApplyConfiguration(new TagConfig());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidValueConverter>();
    }
}
