using System;
using System.Collections.Generic;

namespace lab2 
{
    class Artist
    {
        public String Name;
        public Genre Genre;
        //public List<Track> Tracks = new List<Track>(); если есть треки, не привязанные к альбому
        public List<Album> Albums = new List<Album>();

        public Artist(string name, Genre genre)
        {
            this.Name = name;
            this.Genre = genre;
        }

        //public void AddTrack(Track track)
        //{
        //    this.Tracks.Add(track);
        //}
        
        public void AddAlbum(Album album)
        {
            this.Albums.Add(album);
        }
    }

    class Track
    {
        public Artist Artist;
        public Album Album;
        public String Name;
        public Genre Genre;

        public Track(Artist artist, string name)
        {
            this.Artist = artist;
            this.Name = name;
            this.Genre = artist.Genre;
        }
    }

    class Album
    {
        public String Name;
        public int Year;
        public Artist Artist;
        public List<Track> Tracks = new List<Track>();

        public Album(String name, int year, Artist artist)
        {
            this.Name = name;
            this.Year = year;
            this.Artist = artist;
        }

        public void AddTrack(Track track)
        {
            if (track.Artist == this.Artist)
            {
                track.Album = this;
                this.Tracks.Add(track);
            }
        }
    }

    class Catalog
    {
        public List<Album> Albums = new List<Album>();
        public List<Track> TrackCollection = new List<Track>();

        public void AddAlbum(Album album)
        {
            this.Albums.Add(album);
        }

        public void AddTrack(Track track)
        {
            this.TrackCollection.Add(track);
        }
    }
    
    class Genre
    {
        public String Name;
        public List<Genre> ChildGenres = new List<Genre>();

        public Genre(String name)
        {
            this.Name = name;
        }
    }

    class SubGenre
    {
        public List<Genre> ParentGenres = new List<Genre>();
    }
}