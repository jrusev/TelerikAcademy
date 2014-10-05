namespace Musicians.ConsoleClient.Models
{
    public class SongModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Year { get; set; }

        public string Length { get; set; }

        public int ArtistId { get; set; }  
    }
}