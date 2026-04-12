using Microsoft.EntityFrameworkCore;
using SevDocs.Stores.Jobs;

namespace SevDocs.Stores;

public class JobsDbContext(DbContextOptions<JobsDbContext> options) : DbContext(options)
{
    public DbSet<JobRecord> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobRecord>(b =>
        {
            b.HasKey(x => x.TrackingID);
        });
    }
}
