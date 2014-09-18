namespace Musicians.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Musicians.Models;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Genre = s.Genre,
                    Year = s.Year,
                    Length = s.Length,
                    Artist = s.Artist.Name
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        public short Year { get; set; }

        public double Length { get; set; }

        public string Artist { get; set; }
    }
}