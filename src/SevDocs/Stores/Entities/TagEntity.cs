namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents tag
/// </summary>
public class TagEntity
{
    /// <summary>
    /// Unique tag ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Tag name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ID of <see cref="TagCategoryEntity"/> to which tag is assigned
    /// </summary>
    public Ulid TagCategoryId { get; set; }

    /// <summary>
    /// ID of tag owner. <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    public AppUser User { get; set; }
    public TagCategoryEntity TagCategory { get; set; }
    public List<FolderEntity> Folders { get; set; } = [];
    public List<FolderTagEntity> FolderTags { get; set; } = [];
}
