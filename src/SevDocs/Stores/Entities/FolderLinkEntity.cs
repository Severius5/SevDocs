namespace SevDocs.Stores.Entities
{
    /// <summary>
    /// Represents a link between two <see cref="FolderEntity"/>, modeling a parent-child relationship
    /// </summary>
    public class FolderLinkEntity
    {
        /// <summary>
        /// ID of parent <see cref="FolderEntity"/>
        /// </summary>
        public Ulid FolderLinksId { get; set; }

        /// <summary>
        /// ID of child <see cref="FolderEntity"/>
        /// </summary>
        public Ulid FolderLinkedId { get; set; }

        public FolderEntity FolderLinks { get; set; }
        public FolderEntity FolderLinked { get; set; }
    }
}
