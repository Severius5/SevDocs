namespace SevDocs.Stores.Jobs;

internal class JobsOptions
{
    public JobRetryOption Retry { get; set; }

    private readonly Dictionary<string, JobRetryOption> _jobRetries = [];

    public void ConfigureRetries<TJob>(int? retries = null, TimeSpan? delay = null)
    {
        _jobRetries[GetKey<TJob>()] = new JobRetryOption
        {
            Delay = delay ?? Retry.Delay,
            Retries = retries ?? Retry.Retries
        };
    }

    public JobRetryOption GetRetryFor(string key)
    {
        if (_jobRetries.TryGetValue(key, out var opt))
            return opt;

        return Retry;
    }

    internal static string GetKey<TJob>()
    {
        return typeof(TJob).AssemblyQualifiedName;
    }
}
