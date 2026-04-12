using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SevDocs.Stores.Jobs;

internal class JobsStorage(IDbContextFactory<JobsDbContext> dbContextFactory, IOptions<JobsOptions> options) : IJobStorageProvider<JobRecord>
{
    public bool DistributedJobProcessingEnabled => false;

    public async Task CancelJobAsync(Guid trackingId, CancellationToken ct)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        await dbContext.Jobs
            .TagWithCallSite()
            .Where(x => x.TrackingID == trackingId)
            .ExecuteUpdateAsync(update => update
                .SetProperty(x => x.IsComplete, true),
                ct);
    }

    public async Task<ICollection<JobRecord>> GetNextBatchAsync(PendingJobSearchParams<JobRecord> parameters)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        return await dbContext.Jobs
            .TagWithCallSite()
            .Where(parameters.Match)
            .Take(parameters.Limit)
            .ToListAsync(parameters.CancellationToken);
    }

    public async Task MarkJobAsCompleteAsync(JobRecord r, CancellationToken ct)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        dbContext.Update(r);

        await dbContext.SaveChangesAsync(ct);
    }

    public async Task OnHandlerExecutionFailureAsync(JobRecord r, Exception exception, CancellationToken ct)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        var opt = options.Value.GetRetryFor(r.CommandKey);

        if (r.Retries >= opt.Retries)
        {
            r.IsComplete = true;
        }
        else
        {
            r.Retries++;
            r.ExecuteAfter = DateTime.UtcNow.Add(opt.Delay);
        }

        dbContext.Update(r);

        await dbContext.SaveChangesAsync(ct);
    }

    public async Task PurgeStaleJobsAsync(StaleJobSearchParams<JobRecord> parameters)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        await dbContext.Jobs
            .TagWithCallSite()
            .Where(parameters.Match)
            .ExecuteDeleteAsync(parameters.CancellationToken);
    }

    public async Task StoreJobAsync(JobRecord r, CancellationToken ct)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        dbContext.Add(r);

        await dbContext.SaveChangesAsync(ct);
    }
}
