namespace EFZipContext.Models;

public class FileEntity
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public double FileSize { get; set; } = 0;
    public int ArchiveId { get; set; }
    public ArchiveEntity Archive { get; set; }
}