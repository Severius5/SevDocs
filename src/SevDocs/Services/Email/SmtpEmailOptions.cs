namespace SevDocs.Services.Email
{
    internal class SmtpEmailOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderName { get; init; }
        public string SenderEmail { get; init; }
        public bool UseSsl { get; set; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
