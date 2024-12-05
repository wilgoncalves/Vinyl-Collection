namespace VinylCollection.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string? TitleName { get; set; }
        public int RecordedYear { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public Title()
        {

        }

        public Title(int id, string? titleName, int recordedYear, Artist? artist)
        {
            Id = id;
            TitleName = titleName;
            RecordedYear = recordedYear;
            Artist = artist;
        }
    }
}
