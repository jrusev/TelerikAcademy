namespace Musicians.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Musicians.Models;

    public class ArtistModels
    {
        public static Expression<Func<Artist, ArtistModels>> FromArtist
        {
            get
            {
                return a => new ArtistModels
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country,
                    BirthDate = a.BirthDate,
                    WebSite = a.WebSite
                };
            }
        }

        public static Expression<Func<Artist, ArtistModels>> FromArtistWithSongs
        {
            get
            {
                return a => new ArtistModels
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country,
                    BirthDate = a.BirthDate,
                    WebSite = a.WebSite,
                    Songs = a.Songs.Select(s => new SongModel
                    {
                        Title = s.Title
                    })
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string WebSite { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }      
    }
}