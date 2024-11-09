using System.Data.Common;

namespace EFZipContext.Models;

public class ArchiveEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public float Size { get; set; } = 0;
    public List<FileEntity> Files { get; set; } = [];
}