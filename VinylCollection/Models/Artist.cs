namespace VinylCollection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string? ArtistName { get; set; }
        public ICollection<Title>? Titles { get; set; } 

        public Artist()
        {

        }

        public Artist(int id, string? artistName)
        {
            Id = id;
            ArtistName = artistName;
        }

        public void AddTitle(Title title)
        {
            Titles!.Add(title);
        }

        public void RemoveTitle(Title title)
        {
            Titles!.Remove(title);
        }

        public int TotalTitles()
        {
            return Titles!.Count();
        }
    }
}
