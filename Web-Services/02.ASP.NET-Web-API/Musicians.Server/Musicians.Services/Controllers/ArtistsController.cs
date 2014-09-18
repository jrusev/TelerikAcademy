namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;

    public class ArtistsController : ApiController
    {
        private readonly IMusiciansData data;

        public ArtistsController()
            : this(new MusiciansData())
        {
        }

        public ArtistsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModels.FromArtist);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult AllWithSongs()
        {
            var artists = this.data
                .Artists
                .All()
                .Select(ArtistModels.FromArtistWithSongs);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data
            .Artists
                .All()
                .Where(a => a.Id == id)
                .Select(ArtistModels.FromArtist)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist does not exist - invalid id");
            }

            return this.Ok(artist);
        }

        [HttpGet]
        public IHttpActionResult ByName(string id)
        {
            var artist = this.data
            .Artists
                .All()
                .Where(a => a.Name == id)
                .Select(ArtistModels.FromArtist)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest("Artist does not exist - invalid name");
            }

            return this.Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModels artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = new Artist
            {
                Name = artistModel.Name,
                Country = artistModel.Country,
                BirthDate = artistModel.BirthDate,
                WebSite = artistModel.WebSite
            };

            this.data.Artists.Add(artist);
            this.data.SaveChanges();

            artistModel.Id = artist.Id;
            return this.Ok(artistModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModels artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artistToUpdate = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (artistToUpdate == null)
            {
                return this.BadRequest("Such artist does not exists!");
            }

            artistToUpdate.Name = artistModel.Name;
            artistToUpdate.Country = artistModel.Country;
            artistToUpdate.BirthDate = artistModel.BirthDate;
            if (artistModel.WebSite != null)
            {
                artistToUpdate.WebSite = artistModel.WebSite;
            }
            
            this.data.SaveChanges();

            var updatedArtistModel = new
            {
                Id = artistToUpdate.Id,
                Name = artistToUpdate.Name,
                Country = artistToUpdate.Country,
                BirthDate = artistToUpdate.BirthDate,
                WebSite = artistToUpdate.WebSite
            };

            return this.Ok(updatedArtistModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artistToDelete = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (artistToDelete == null)
            {
                return this.BadRequest("Such artist does not exists!");
            }

            this.data.Artists.Delete(artistToDelete);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(int artistId, int albumId)
        {
            var artist = this.data.Artists.All().FirstOrDefault(a => a.Id == artistId);
            if (artist == null)
            {
                return this.BadRequest("Such artist does not exists - invalid id!");
            }

            var album = this.data.Albums.All().FirstOrDefault(a => a.Id == albumId);
            if (album == null)
            {
                return this.BadRequest("Such album does not exists - invalid id!");
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddSong(int id, int songId)
        {
            var artist = this.data.Artists.All().FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return this.BadRequest("Such artist does not exists - invalid id!");
            }

            var song = this.data.Songs.All().FirstOrDefault(s => s.Id == songId);
            if (song == null)
            {
                return this.BadRequest("Such song does not exists - invalid id!");
            }

            artist.Songs.Add(song);
            this.data.SaveChanges();

            return this.Ok();
        }

    }
}