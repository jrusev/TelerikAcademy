namespace Musicians.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        public short Year { get; set; }

        public double Length { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
