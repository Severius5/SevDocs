using Microsoft.AspNetCore.Identity;

namespace SevDocs.Stores.Entities;

/// <summary>
/// Application user
/// </summary>
public class AppUser : IdentityUser<Ulid>
{
    [PersonalData]
    public string FirstName { get; set; }

    [PersonalData]
    public string LastName { get; set; }

    public List<TagEntity> Tags { get; set; } = [];
    public List<FolderEntity> Folders { get; set; } = [];
    public List<PersonEntity> Persons { get; set; } = [];
    public List<EquipmentEntity> Equipments { get; set; } = [];
    public List<TagCategoryEntity> TagCategories { get; set; } = [];
    public List<OrganizationEntity> Organizations { get; set; } = [];
}

