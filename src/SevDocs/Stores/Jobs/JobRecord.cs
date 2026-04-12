using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SevDocs.Stores.Jobs;

public class JobRecord : IJobStorageRecord
{
    public string QueueID { get; set; }
    public Guid TrackingID { get; set; }
    public DateTime ExecuteAfter { get; set; }
    public DateTime ExpireOn { get; set; }
    public bool IsComplete { get; set; }
    public string CommandJson { get; set; }
    public int Retries { get; set; }
    public string CommandKey { get; set; }

    [NotMapped]
    public object Command { get; set; }

    TCommand IJobStorageRecord.GetCommand<TCommand>()
    {
        return JsonSerializer.Deserialize<TCommand>(CommandJson);
    }

    void IJobStorageRecord.SetCommand<TCommand>(TCommand command)
    {
        CommandJson = JsonSerializer.Serialize(command);
        CommandKey = JobsOptions.GetKey<TCommand>();
    }
}
