namespace Musicians.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Musicians.ConsoleClient.Models;

    public class EntryPoint
    {
        private const string ServerUri = "http://localhost:8570/";
        private const string HeaderValue = "application/json";

        private const string Artists = "api/Artists/";
        private const string Songs = "api/Songs/";
        private const string Albums = "api/Albums/";

        private const string All = "All";
        private const string AllWithSongs = "AllWithSongs";
        private const string Create = "Create";
        private const string ById = "ById/";
        private const string ByName = "ByName/";
        private const string ByTitle = "ByTitle/";
        private const string Update = "Update/";
        private const string Delete = "Delete/";

        private const string AddSong = "AddSong/";
        private const string AddArtist = "AddArtist/";

        private static readonly HttpClient client = new HttpClient 
        {
            BaseAddress = new Uri(ServerUri) 
        };

        private static void Main()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValue));

            CreateArtist("Beyonce", "US", "1980-01-01", "www.beyonce.com");
            CreateArtist("Rhianna", "Barbados", "1982-01-01", "www.rhianna.com");

            CerateSong("Halo", "Pop", "2008", "5.0", 1);
            CerateSong("Single Ladies", "HipHop", "2013", "6.0", 1);
            CerateSong("Umbrella", "Ballad", "2010", "4.0", 2);

            CreateAlbum("Beyonce's best", "2008", "2");
            CreateAlbum("Rhianna's superhits", "2010", "2");

            AddSongToAlbum(1, 1);
            AddSongToAlbum(1, 2);
            AddSongToAlbum(2, 3);

            GetAllAlbums();
            GetAllArtists();
            GetAllSongs();

            GetSongById(1);
            GetSongByTitle("Umbrella");

            UpdateArtist(2, "Rhianna", "UK", "1982-01-01", "www.RH.com");
            GetArtistByName("Rhianna");

            DeleteSong(1);
            GetSongById(1);
        }

        private static void DeleteSong(int id)
        {
            Console.Write("Deleting song with id {0}... ", id);

            HttpResponseMessage response = client.DeleteAsync(Songs + Delete + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void UpdateArtist(int id, string newName, string newCountry, string newBirthDate, string newWebSite)
        {
            Console.Write("Updating artist... ");
            var artist = new ArtistModels
            {
                Name = newName,
                Country = newCountry,
                BirthDate = newBirthDate,
                WebSite = newWebSite
            };

            HttpResponseMessage response = client.PutAsJsonAsync(Artists + Update + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetArtistByName(string name)
        {
            Console.Write("Artist with name {0}: ", name);
            HttpResponseMessage response = client.GetAsync(Artists + ByName + name).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModels>().Result;

                Console.WriteLine("Id : {0}, Name: {1}, Birthdate: {2}, Country : {3}, Website : {4}"
                        , artist.Id, artist.Name, artist.BirthDate, artist.Country, artist.WebSite);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetSongById(int id)
        {
            Console.Write("Song with Id {0}: ", id);
            HttpResponseMessage response = client.GetAsync(Songs + ById + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;

                Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetSongByTitle(string title)
        {
            Console.Write("Song with title {0}: ", title);
            HttpResponseMessage response = client.GetAsync(Songs + ByTitle + title).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;

                Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void AddSongToAlbum(int albumId, int songId)
        {
            var postData = new List<KeyValuePair<string, string>>();
            HttpContent content = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = client.PostAsync(Albums + AddSong + albumId + "?songId=" + songId, content).Result;

        }

        private static void CreateAlbum(string title, string year, string numberOfSongs)
        {
            Console.Write("Creating album... ");
            var album = new AlbumModel
            {
                Title = title,
                NumberOfSongs = numberOfSongs,
                Year = year,
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Albums + Create, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void CerateSong(string title, string genre, string year, string length, int artistId)
        {
            Console.Write("Creating song... ");
            var song = new SongModel
            {
                Title = title,
                Genre = genre,
                Year = year,
                Length = length,
                ArtistId = artistId
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Songs + Create, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void CreateArtist(string name, string country, string birthdate, string website)
        {
            Console.Write("Creating artist... ");
            var artist = new ArtistModels 
            { 
                Name = name, 
                Country = country,
                BirthDate = birthdate,
                WebSite = website
            };

            HttpResponseMessage response = client.PostAsJsonAsync(Artists + Create, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums()
        {
            Console.WriteLine("Albums:");
            HttpResponseMessage response = client.GetAsync(Albums + AllWithSongs).Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;

                foreach (var album in albums)
                {
                    Console.WriteLine("Id : {0}, Title: {1}, Number of songs: {2}, Year : {3}"
                        , album.Id, album.Title, album.NumberOfSongs, album.Year);

                    Console.WriteLine("Songs from album {0}:", album.Title);

                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine(song.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetAllArtists()
        {
            Console.WriteLine("Artists:");
            HttpResponseMessage response = client.GetAsync(Artists + AllWithSongs).Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModels>>().Result;

                foreach (var artist in artists)
                {
                    Console.WriteLine("Id : {0}, Name: {1}, Birthdate: {2}, Country : {3}, Website : {4}"
                        , artist.Id, artist.Name, artist.BirthDate, artist.Country, artist.WebSite);

                    Console.WriteLine("Songs by {0}:", artist.Name);
                    foreach (var song in artist.Songs)
                    {
                        Console.WriteLine(song.Title);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }

        private static void GetAllSongs()
        {
            Console.WriteLine("All songs:");
            HttpResponseMessage response = client.GetAsync(Songs + All).Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;

                foreach (var song in songs)
                {
                    Console.WriteLine("Id : {0}, Title: {1}, Length: {2}, Year : {3}"
                        , song.Id, song.Title, song.Length, song.Year);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.WriteLine(".............................");
        }
    }
}
