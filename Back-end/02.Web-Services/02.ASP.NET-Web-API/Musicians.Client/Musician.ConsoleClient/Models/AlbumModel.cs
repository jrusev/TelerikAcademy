namespace Musicians.ConsoleClient.Models
{
    using System.Collections.Generic;

    public class AlbumModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string NumberOfSongs { get; set; }

        public ICollection<SongModel> Songs { get; set; }
    }
}