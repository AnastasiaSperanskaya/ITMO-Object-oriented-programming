using System;
using System.Collections.Generic;

namespace lab2
{
    class Search
    {
        public Catalog catalog;

        public Search(Catalog catalog)
        {
            this.catalog = catalog;
        }

        public void MultiPurposeTrackSearch()
        {
            String albumName;
            String artistName;
            String genreName;

            Console.Write("Введите имя артиста:");
            artistName = Console.ReadLine();
            
            Console.Write("Введите имя альбома:");
            albumName = Console.ReadLine();

            Console.Write("Введите имя жанра:");
            genreName = Console.ReadLine();

            var allTracks = new List<Track>();
            
            //артист и жанр и альбом
            if (!string.IsNullOrWhiteSpace(genreName) && !string.IsNullOrWhiteSpace(albumName) &&
                !string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Album.Name == albumName &&
                            B.Artist.Name == artistName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //жанр и альбом
            if (!string.IsNullOrWhiteSpace(genreName) && !string.IsNullOrWhiteSpace(albumName) &&
                string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //жанр и артист
            if (!string.IsNullOrWhiteSpace(genreName) && string.IsNullOrWhiteSpace(albumName) &&
                !string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Artist.Name == artistName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName && B.Artist.Name == artistName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //альбом и артист
            if (string.IsNullOrWhiteSpace(genreName) && !string.IsNullOrWhiteSpace(albumName) &&
                !string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) &&  B.Artist.Name == artistName && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Artist.Name == artistName && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //артист
            if (string.IsNullOrWhiteSpace(genreName) && string.IsNullOrWhiteSpace(albumName) &&
                !string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Artist.Name == artistName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Artist.Name == artistName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //жанр
            if (!string.IsNullOrWhiteSpace(genreName) && string.IsNullOrWhiteSpace(albumName) &&
                string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Genre.Name == genreName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //альбом
            if (string.IsNullOrWhiteSpace(genreName) && !string.IsNullOrWhiteSpace(albumName) &&
                string.IsNullOrWhiteSpace(artistName))
            {
                foreach (var A in this.catalog.Albums)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }

                foreach (var A in this.catalog.TrackCollection)
                {
                    foreach (var B in A.Tracks)
                    {
                        if (!allTracks.Contains(B) && B.Album.Name == albumName)
                            allTracks.Add(B);
                    }
                }
            }
            
            //если все поля пустые
            if (string.IsNullOrWhiteSpace(genreName) && string.IsNullOrWhiteSpace(albumName) &&
                string.IsNullOrWhiteSpace(artistName))
            {
                Console.WriteLine("None of the criterions were filled");
                return;
            }

            Console.Write("All Songs with your criterions are: ");
            foreach (var A in allTracks)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }
        public void SearchArtists()
        {
            List<Artist> allArtists = new List<Artist>();
            foreach (var A in this.catalog.Albums)
            {
                if(!allArtists.Contains(A.Artist))
                    allArtists.Add(A.Artist);
            }
            foreach (var A in this.catalog.TrackCollection)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allArtists.Contains(B.Artist))
                        allArtists.Add(B.Artist);
                }
            }
            
            Console.Write("All Artists in " + catalog.Name + " are: ");
            foreach (var A in allArtists)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }

        public void SearchAlbums()
        {
            List<Album> allAlbums = new List<Album>();
            foreach (var A in this.catalog.Albums)
            {
                if(!allAlbums.Contains(A))
                    allAlbums.Add(A);
            }

            foreach (var A in this.catalog.TrackCollection)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allAlbums.Contains(B.Album))
                        allAlbums.Add(B.Album);
                }
            }

            Console.Write("All Albums in " + catalog.Name + " are: ");
            foreach (var A in allAlbums)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }

        public void SearchTrackCollection()
        {
            List<TrackCollection> allTrackCollections = new List<TrackCollection>();
            foreach (var A in this.catalog.TrackCollection)
            {
                if(!allTrackCollections.Contains(A))
                    allTrackCollections.Add(A);
            }
            
            foreach (var A in allTrackCollections)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }

        public void SearchArtistsWithGenre(Genre genre)
        {
            List<Artist> allArtists = new List<Artist>();
            foreach (var A in this.catalog.Albums)
            {
                if(!allArtists.Contains(A.Artist) && (A.Artist.Genre == genre))
                    allArtists.Add(A.Artist);
            }
            foreach (var A in this.catalog.TrackCollection)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allArtists.Contains(B.Artist) && (B.Artist.Genre == genre))
                        allArtists.Add(B.Artist);
                }
            }
            
            Console.Write("All Artists in " + this.catalog.Name + " with genre " + genre.Name + " are: ");
            foreach (var A in allArtists)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }
    }
}