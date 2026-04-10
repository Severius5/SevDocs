namespace SevDocs.Services.Email
{
    public record Mailbox(string Name, string Email)
    {
        public static implicit operator Mailbox(AppUser user) => new Mailbox($"{user.FirstName} {user.LastName}", user.Email);
    }
}
