namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;
    
    public class AlbumsController : ApiController
    {
        private readonly IMusiciansData data;

        public AlbumsController()
            : this(new MusiciansData())
        {
        }

        public AlbumsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbum);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult AllWithSongs()
        {
            var albums = this.data
                .Albums
                .All()
                .Select(AlbumModel.FromAlbumWithSongs);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.data
                .Albums
                .All()
                .Where(s => s.Id == id)
                .Select(AlbumModel.FromAlbum)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Album does not exist - invalid id");
            }

            return this.Ok(album);
        }

        [HttpGet]
        public IHttpActionResult ByTitle(string id)
        {
            var album = this.data
                .Albums
                .All()
                .Where(s => s.Title == id)
                .Select(AlbumModel.FromAlbum)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("Album does not exist - invalid title");
            }

            return this.Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAlbum = new Album
            {
                Title = albumModel.Title,
                NumberOfSongs = albumModel.NumberOfSongs,
                Year = albumModel.Year,
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            albumModel.Id = newAlbum.Id;
            return this.Ok(albumModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumToUpdate = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (albumToUpdate == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            albumToUpdate.Title = albumModel.Title;
            albumToUpdate.Year = albumModel.Year;

            if (albumModel.NumberOfSongs != null)
            {
                albumToUpdate.NumberOfSongs = albumModel.NumberOfSongs;
            }
                      
            this.data.SaveChanges();

            var updatedAlbumModel = new
            {
                Id = albumToUpdate.Id,
                Title = albumToUpdate.Title,
                NumberOfSongs = albumToUpdate.NumberOfSongs,
                Year = albumToUpdate.Year
            };

            return this.Ok(updatedAlbumModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var albumToDelete = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (albumToDelete == null)
            {
                return this.BadRequest("Such album does not exists!");
            }

            this.data.Albums.Delete(albumToDelete);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.BadRequest("Such album does not exists - invalid id!");
            }

            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == songId);
            if (song == null)
            {
                return this.BadRequest("Such song does not exists - invalid id!");
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}