namespace Musicians.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Musicians.Models;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    NumberOfSongs = a.NumberOfSongs,
                    Year = a.Year
                };
            }
        }

        public static Expression<Func<Album, AlbumModel>> FromAlbumWithSongs
        {
            get
            {
                return a => new AlbumModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    NumberOfSongs = a.NumberOfSongs,
                    Year = a.Year,
                    Songs = a.Songs.Select(s => new SongModel
                    {
                        Title = s.Title
                    })
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public short Year { get; set; }

        public short NumberOfSongs { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}