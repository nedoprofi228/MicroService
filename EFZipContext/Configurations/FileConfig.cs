using EFZipContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFZipContext.Configurations;

public class FileConfig : IEntityTypeConfiguration<FileEntity>
{
    public void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(a => a.Archive)
            .WithMany(b => b.Files);
    }
}