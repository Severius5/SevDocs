namespace SevDocs.Stores.Entities
{
    /// <summary>
    /// Represents the association between a <see cref="FolderEntity"/> and a <see cref="TagEntity"/>.
    /// </summary>
    public class FolderTagEntity
    {
        /// <summary>
        /// ID of <see cref="FolderEntity"/>
        /// </summary>
        public Ulid FolderId { get; set; }

        /// <summary>
        /// ID of <see cref="TagEntity"/>
        /// </summary>
        public Ulid TagId { get; set; }

        public FolderEntity Folder { get; set; }
        public TagEntity Tag { get; set; }
    }
}
