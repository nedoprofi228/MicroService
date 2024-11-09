using EFZipContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFZipContext.Configurations;

public class ArchiveConfig : IEntityTypeConfiguration<ArchiveEntity>
{
    public void Configure(EntityTypeBuilder<ArchiveEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(a => a.Files)
            .WithOne(b => b.Archive)
            .HasForeignKey(c => c.ArchiveId);
    }
}