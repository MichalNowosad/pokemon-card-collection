using Microsoft.AspNetCore.Http;
using PokemonCardCollection.Application.Models.File;

namespace PokemonCardCollection.Application.Interfaces.Infrastructure
{
    public interface IFileService
    {
        Task<FileNameDto> SaveFile(IFormFile file, string folderName);
        Task<MemoryStream> GetFileStream(string fileName, string folderName);
        void DeleteFile(string fileName, string folderName);
    }
}
