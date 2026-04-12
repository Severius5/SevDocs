using SevDocs.Services.Email;
using SevDocs.Templates;

namespace SevDocs.Features.SendEmail;

internal class Handler(IServiceScopeFactory serviceScopeFactory) : ICommandHandler<SendEmailJob>
{
    public async Task ExecuteAsync(SendEmailJob command, CancellationToken ct)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();

        var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
        var renderer = scope.ServiceProvider.GetRequiredService<ITemplateRenderer>();

        var body = await renderer.RenderAsync(command.Template);

        await emailSender.SendEmailAsync(command.Receiver, command.Template.Subject, body, ct);
    }
}
