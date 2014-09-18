namespace Musicians.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Musicians.Data;
    using Musicians.Models;
    using Musicians.Services.Models;

    public class SongsController : ApiController
    {
        private readonly IMusiciansData data;

        public SongsController()
            : this(new MusiciansData())
        {
        }

        public SongsController(IMusiciansData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data
                .Songs
                .All()
                .Select(SongModel.FromSong);

            return this.Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.data
                .Songs
                .All()
                .Where(s => s.Id == id)
                .Select(SongModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Song does not exist - invalid id");
            }

            return this.Ok(song);
        }

        [HttpGet]
        public IHttpActionResult ByTitle(string id)
        {
            var song = this.data
                .Songs
                .All()
                .Where(s => s.Title == id)
                .Select(SongModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest("Song does not exist - invalid title");
            }

            return this.Ok(song);
        }

        [HttpPost]
        public IHttpActionResult Create(Song song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newSong = new Song
            {
                Title = song.Title,
                Genre = song.Genre,
                Length = song.Length,
                Year = song.Year,
                ArtistId = song.ArtistId
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();

            song.Id = newSong.Id;
            return this.Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var songToUpdate = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (songToUpdate == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            songToUpdate.Title = songModel.Title;

            if (songModel.Genre != null)
            {
                songToUpdate.Genre = songModel.Genre;
            }

            if (songModel.Year != 0)
            {
                songToUpdate.Year = songModel.Year;
            }

            if (songModel.Length != 0)
            {
                songToUpdate.Length = songModel.Length;
            }            

            this.data.SaveChanges();

            var updatedSongModel = new
            {
                Id = songToUpdate.Id,
                Genre = songToUpdate.Genre,
                Length = songToUpdate.Length,
                Title = songToUpdate.Title,
                Year = songToUpdate.Year
            };

            return this.Ok(updatedSongModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var songToDelete = this.data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (songToDelete == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            this.data.Songs.Delete(songToDelete);
            this.data.SaveChanges();

            return this.Ok();
        }

    }
}