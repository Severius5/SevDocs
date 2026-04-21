namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents person
/// </summary>
public class PersonEntity
{
    /// <summary>
    /// Unique person ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Display name. Can be full firstname and last name, nickname etc.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Optional notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// ID of person owner. <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    public AppUser User { get; set; }
    public List<ContactEntity> Contacts { get; set; } = [];
}
