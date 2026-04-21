namespace SevDocs.Stores.Entities;

/// <summary>
/// Represent organization
/// </summary>
public class OrganizationEntity
{
    /// <summary>
    /// Unique organization ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Full name of organization
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Short name for organization
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Street where organization is located
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Zipcode 
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// City name where organization is located
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Country in which organization is located
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Optional notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// ID of organization owner. <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    public AppUser User { get; set; }
    public List<ContactEntity> Contacts { get; set; } = [];
    public List<FolderEntity> Folders { get; set; } = [];
}
