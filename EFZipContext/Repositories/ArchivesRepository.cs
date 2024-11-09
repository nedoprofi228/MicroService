using EFZipContext.Models;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace EFZipContext.Repositories;

public class ArchivesRepository(ArchiveContext context) : IRepository<ArchiveEntity>
{
    private readonly ArchiveContext _archiveContext = context;

    public async Task<ArchiveEntity?> GetById(int id)
    {
        return await _archiveContext.Archives
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<ArchiveEntity>> Get()
    {
        return await _archiveContext.Archives.AsNoTracking().ToListAsync();
    }

    public async Task<List<ArchiveEntity>> GetByPage(int pageNumber, int pageSize)
    {
        return await _archiveContext.Archives
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> Put(string name, float size, List<FileEntity> files)
    {
        int id = 0;
        
        var archiveEntity = new ArchiveEntity()
        {
            Id = id,
            Name = name,
            Size = size,
            Files = files
        };
        
        await _archiveContext.Archives.AddAsync(archiveEntity);
        _archiveContext.SaveChanges();

        return id;
    }

    public async Task Put(ArchiveEntity archiveEntity)
    {
        await _archiveContext.Archives.AddAsync(archiveEntity);
        _archiveContext.SaveChanges();
    }
}