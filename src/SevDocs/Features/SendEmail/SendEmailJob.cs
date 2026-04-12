using SevDocs.Services.Email;
using SevDocs.Templates;
using System.Text.Json.Serialization;

namespace SevDocs.Features.SendEmail;

public class SendEmailJob : ICommand
{
    [JsonConverter(typeof(TemplateJobConverter))]
    public ITemplate Template { get; init; }
    public Mailbox Receiver { get; init; }
}
