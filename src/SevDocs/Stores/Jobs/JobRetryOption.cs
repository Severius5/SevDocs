namespace SevDocs.Stores.Jobs;

public class JobRetryOption
{
    /// <summary>
    /// How many times to retry executing job
    /// </summary>
    public int Retries { get; set; } = 3;

    /// <summary>
    /// Minimum delay between retries
    /// </summary>
    public TimeSpan Delay { get; set; } = TimeSpan.FromMinutes(1);
}
