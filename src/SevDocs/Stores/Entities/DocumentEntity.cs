using NpgsqlTypes;

namespace SevDocs.Stores.Entities;

/// <summary>
/// Represents single document file
/// </summary>
public class DocumentEntity
{
    /// <summary>
    /// Unique document ID
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Filename with extension passed when uploading file
    /// </summary>
    public string OriginalFileName { get; set; }

    /// <summary>
    /// File text content obtained from OCR
    /// </summary>
    public string TextContent { get; set; }

    /// <summary>
    /// Optional filename with extension for converted PDF file
    /// </summary>
    public string ConvertedName { get; set; }

    /// <summary>
    /// Optional filename with extension for cover image
    /// </summary>
    public string CoverName { get; set; }

    /// <summary>
    /// Full-text search
    /// </summary>
    public NpgsqlTsVector SearchVector { get; set; }

    /// <summary>
    /// SHA256 file checksum
    /// </summary>
    public string Checksum { get; set; }

    /// <summary>
    /// ID of <see cref="FolderEntity"/> where documents is assigned
    /// </summary>
    public Ulid FolderId { get; set; }

    public FolderEntity Folder { get; set; }
}
