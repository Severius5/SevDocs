using SevDocs.Shared.Models;

namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents contact form for <see cref="PersonEntity"/> or <see cref="OrganizationEntity"/>
/// </summary>
public class ContactEntity
{
    /// <summary>
    /// Uniqie ID of contact
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Type of contact
    /// </summary>
    public ContactType Type { get; set; }

    /// <summary>
    /// Contact form in specified <see cref="Type"/>
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Optional ID of <see cref="PersonEntity"/> to which contact is assiged
    /// </summary>
    public Ulid? PersonId { get; set; }

    /// <summary>
    /// Optional ID of <see cref="OrganizationEntity"/> to which contact is assigned
    /// </summary>
    public Ulid? OrganizationId { get; set; }

    public PersonEntity Person { get; set; }
    public OrganizationEntity Organization { get; set; }
}
