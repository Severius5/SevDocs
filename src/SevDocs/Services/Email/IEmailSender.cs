namespace SevDocs.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Mailbox receiver, string subject, string htmlBody, CancellationToken ct = default);
    }
}
