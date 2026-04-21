namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents collection of <see cref="TagEntity"/> with associated metadata 
/// </summary>
public class TagCategoryEntity
{
    /// <summary>
    /// Unique category ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Category name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Color in hex format
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// ID of category owner. <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    public AppUser User { get; set; }
    public List<TagEntity> Tags { get; set; } = [];
}
