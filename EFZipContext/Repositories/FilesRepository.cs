using Core.Interfaces;
using EFZipContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EFZipContext.Repositories;

public class FilesRepository(ArchiveContext context) : IRepository<FileEntity>
{
    
    public async Task<List<FileEntity>> Get(int archiveId)
    {
        return await context.Files
            .Where(a => a.ArchiveId == archiveId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<FileEntity?> GetById(int archiveId, int fileId)
    {
        return await context.Files
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArchiveId == archiveId && a.Id == fileId);
    }

    public async Task<List<FileEntity>> GetByPage(int pageNumber, int pageSize)
    {
        return await context.Files
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<List<FileEntity>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<FileEntity?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task Put(FileEntity file)
    {
        var archive = await context.Archives
            .Where(a => a.Id == file.Id)
            .FirstOrDefaultAsync() ?? throw new Exception("archive not found");
        
        archive.Files.Add(file);

        await context.SaveChangesAsync();
    }
}