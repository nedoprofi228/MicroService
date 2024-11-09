using EFZipContext.Configurations;
using EFZipContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EFZipContext;

public class ArchiveContext(DbContextOptions<ArchiveContext> options)
    : DbContext(options)
{
    public DbSet<FileEntity> Files { get; set; }
    public DbSet<ArchiveEntity> Archives { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArchiveConfig());
        modelBuilder.ApplyConfiguration(new FileConfig()); 
        base.OnModelCreating(modelBuilder);
    }
}