using NpgsqlTypes;

namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents a collection of documents with associated metadata
/// </summary>
public class FolderEntity
{
    /// <summary>
    /// Unique folder ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Folder title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Optional notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// MD5 hash of <see cref="Id"/>
    /// </summary>
    public string IdHash { get; set; }

    /// <summary>
    /// Whether folder wasn't edited since uploading
    /// </summary>
    public bool IsNew { get; set; }

    /// <summary>
    /// Assigned date by user for folder
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Date when folder was created
    /// </summary>
    public DateTimeOffset CreateDate { get; set; }

    /// <summary>
    /// Date when folder was last modified
    /// </summary>
    public DateTimeOffset UpdateDate { get; set; }

    /// <summary>
    /// Full-text search
    /// </summary>
    public NpgsqlTsVector SearchVector { get; set; }

    /// <summary>
    /// ID of folder owner, <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    /// <summary>
    /// Optional ID of sender/correspondent <see cref="PersonEntity"/>
    /// </summary>
    public Ulid? SenderPersonId { get; set; }

    /// <summary>
    /// Optional ID of receiver/concerning <see cref="PersonEntity"/>
    /// </summary>
    public Ulid? ReceiverPersonId { get; set; }

    /// <summary>
    /// Optional ID of <see cref="EquipmentEntity"/>
    /// </summary>
    public Ulid? EquipmentId { get; set; }

    /// <summary>
    /// Optional ID of sender/correspondent <see cref="OrganizationEntity"/>
    /// </summary>
    public Ulid? SenderOrganizationId { get; set; }

    /// <summary>
    /// Optional ID of receiver/concerning <see cref="OrganizationEntity"/>
    /// </summary>
    public Ulid? ReceiverOrganizationId { get; set; }

    public AppUser User { get; set; }
    public PersonEntity SenderPerson { get; set; }
    public PersonEntity ReceiverPerson { get; set; }
    public EquipmentEntity Equipment { get; set; }
    public OrganizationEntity SenderOrganization { get; set; }
    public OrganizationEntity ReceiverOrganization { get; set; }
    public List<TagEntity> Tags { get; set; } = [];
    public List<FolderTagEntity> FolderTags { get; set; } = [];
    public List<FolderEntity> Links { get; set; } = [];
    public List<FolderEntity> LinkedBy { get; set; } = [];
    public List<DocumentEntity> Documents { get; set; } = [];
}
