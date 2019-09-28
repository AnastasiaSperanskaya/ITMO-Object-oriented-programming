using System;
using System.Collections.Generic;

namespace lab2
{
    class Search
    {
        public void SearchArtists(Catalog catalog)
        {
            List<Artist> allArtists = new List<Artist>();
            foreach (var A in catalog.Albums)
            {
                if(!allArtists.Contains(A.Artist))
                    allArtists.Add(A.Artist);
            }
            foreach (var A in catalog.TrackCollection)
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

        public void SearchAlbums(Catalog catalog)
        {
            List<Album> allAlbums = new List<Album>();
            foreach (var A in catalog.Albums)
            {
                if(!allAlbums.Contains(A))
                    allAlbums.Add(A);
            }

            foreach (var A in catalog.TrackCollection)
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

        public void SearchTrackCollection(Catalog catalog)
        {
            List<TrackCollection> allTrackCollections = new List<TrackCollection>();
            foreach (var A in catalog.TrackCollection)
            {
                if(!allTrackCollections.Contains(A))
                    allTrackCollections.Add(A);
            }
            
            foreach (var A in allTrackCollections)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }

        public void SearchSongWithGenre(Catalog catalog, Genre genre)
        {
            var allSongsWithGenre = new List<Track>();
            
            foreach (var A in catalog.Albums)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allSongsWithGenre.Contains(B) && B.Genre == genre)
                        allSongsWithGenre.Add(B);
                }
            }
            
            foreach (var A in catalog.TrackCollection)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allSongsWithGenre.Contains(B) && B.Genre == genre)
                        allSongsWithGenre.Add(B);
                }
            }
            
            Console.Write("All Songs in " + catalog.Name + " with genre " + genre.Name +  " are: ");
            foreach (var A in allSongsWithGenre)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }
        
        public void SearchArtistsWithGenre(Catalog catalog, Genre genre)
        {
            List<Artist> allArtists = new List<Artist>();
            foreach (var A in catalog.Albums)
            {
                if(!allArtists.Contains(A.Artist) && (A.Artist.Genre == genre))
                    allArtists.Add(A.Artist);
            }
            foreach (var A in catalog.TrackCollection)
            {
                foreach (var B in A.Tracks)
                {
                    if(!allArtists.Contains(B.Artist) && (B.Artist.Genre == genre))
                        allArtists.Add(B.Artist);
                }
            }
            
            Console.Write("All Artists in " + catalog.Name + " with genre " + genre.Name + " are: ");
            foreach (var A in allArtists)
                Console.Write("<" + A.Name + ">" + " ");
            
            Console.WriteLine();
        }
    }
}