using System.IO.Compression;
using Core.Interfaces;
using EFZipContext.Models;
using System.Linq.Expressions;

namespace NewWebApplication;

public class ProccesFileData(IRepository<ArchiveEntity> repository)
{
    public async Task ProcessZip(IFormFile formFile)
    {
        List<FileEntity> fileEntities = [];
        ZipArchive zip = new ZipArchive(formFile.OpenReadStream(), ZipArchiveMode.Read);

        foreach (var file in zip.Entries)
        {
            fileEntities.Add(new FileEntity()
            {
                FileName = file.FullName,
                FileSize = file.Length,
            });
        }
        
        await repository.Put(new ArchiveEntity()
        {
            Size = formFile.Length,
            Name = formFile.Name,
            Files = fileEntities
        });
    }

    public async Task<List<ArchiveEntity>> GetArchivesAtPage(int pageNumber, int pageSize)
    {
        return await repository.GetByPage(pageNumber, pageSize);
    }
    
}