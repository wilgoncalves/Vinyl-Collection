namespace VinylCollection.Models.ViewModels
{
    public class ArtistViewModel
    {
        public string? ArtistName { get; set; }
        public List<string>? Titles { get; set; } = new List<string>();
    }
}
