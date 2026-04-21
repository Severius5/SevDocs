namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents equipment
/// </summary>
public class EquipmentEntity
{
    /// <summary>
    /// Unique equimpent ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Equipment name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Optional notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// ID of equipment owner. <see cref="AppUser"/>
    /// </summary>
    public Ulid UserId { get; set; }

    public AppUser User { get; set; }
}
