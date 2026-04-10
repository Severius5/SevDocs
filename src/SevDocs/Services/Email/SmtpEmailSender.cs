using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace SevDocs.Services.Email
{
    internal class SmtpEmailSender(IOptions<SmtpEmailOptions> options) : IEmailSender
    {
        private readonly SmtpEmailOptions _options = options.Value;

        public async Task SendEmailAsync(Mailbox receiver, string subject, string htmlBody)
        {
            using var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_options.SenderName, _options.SenderEmail));
            message.To.Add(new MailboxAddress(receiver.Name, receiver.Email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlBody
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Host, _options.Port, _options.UseSsl);
            if (_options.UseSsl)
                await client.AuthenticateAsync(_options.Username, _options.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
