namespace Musicians.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;

    public class ArtistModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string BirthDate { get; set; }

        public string WebSite { get; set; }

        public ICollection<SongModel> Songs { get; set; }
    }
}