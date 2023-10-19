using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Models.File;

namespace PokemonCardCollection.Infrastructure.Files
{
    public class FileService : IFileService
    {
        private readonly string _rootPath;

        public FileService(IHostEnvironment hostEnvironment)
        {
            _rootPath = hostEnvironment.ContentRootPath;
        }

        public void DeleteFile(string fileName, string folderName)
        {
            var filePath = GetFilePath(fileName, folderName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public async Task<MemoryStream> GetFileStream(string fileName, string folderName)
        {
            var filePath = GetFilePath(fileName, folderName);

            if (!File.Exists(filePath))
            {
                throw new IOException();
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return memory;
        }

        public async Task<FileNameDto> SaveFile(IFormFile file, string folderName)
        {
            var fileName = GetFileNameWithTimestamp(file.FileName);
            var filePath = GetFilePath(fileName, folderName);

            if (File.Exists(filePath))
            {
                throw new IOException();
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new FileNameDto
            {
                FileName = fileName,
                DisplayFileName = file.FileName
            };
        }

        private string GetFilePath(string fileName, string folderName)
        {
            return $"{_rootPath}\\{folderName}\\{fileName}";
        }

        private string GetFileNameWithTimestamp(string fileName)
        {
            return string.Concat(DateTime.UtcNow.Ticks.ToString(), fileName);
        }
    }
}
