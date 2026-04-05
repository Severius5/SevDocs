using Microsoft.AspNetCore.Identity;

namespace SevDocs.Stores.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

