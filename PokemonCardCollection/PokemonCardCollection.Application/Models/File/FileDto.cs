namespace PokemonCardCollection.Application.Models.File
{
    public class FileDto
    {
        public string FileName { get; set; } = string.Empty;
        public string DisplayFileName { get; set; } = string.Empty;
        public MemoryStream? FileStream { get; set; }
    }
}
