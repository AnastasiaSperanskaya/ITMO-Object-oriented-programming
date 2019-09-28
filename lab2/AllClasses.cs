using System;
using System.Collections.Generic;
using System.Linq;

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

        public Track(Artist artist, Album album, string name)
        {
            this.Artist = artist;
            this.Album = album;
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
        public String Name;
        public List<Album> Albums = new List<Album>();
        public List<TrackCollection> TrackCollection = new List<TrackCollection>();

        public Catalog(String name)
        {
            this.Name = name;
        }
        public void AddAlbum(Album album)
        {
            this.Albums.Add(album);
        }

        public void AddTrackCollection(TrackCollection collection)
        {
            this.TrackCollection.Add(collection);
        }
    }

    class TrackCollection
    {
        public String Name;
        public List<Track> Tracks = new List<Track>();

        public TrackCollection(String name)
        {
            this.Name = name;
        }

        public void AddTrack(Track track)
        {
            this.Tracks.Add(track);
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

        public Genre(String name, params SubGenre[] subGenres): this(name)
        {
            foreach (SubGenre genre in subGenres)
                AddChildren(genre);
        }

        public void AddChildren(SubGenre genre)
        {
            this.ChildGenres.Add(genre);
            genre.AddParent(this);
        }

        public bool IsInstanceOrChildren(Genre genre)
        {
            return genre == this || ChildGenres.Any(it => it.IsInstanceOrChildren(genre));
        }
    }

    class SubGenre: Genre
    {

        public List<Genre> ParentGenres = new List<Genre>();

        public SubGenre(String name, params Genre[] parentGenres) : base(name)
        {
            foreach (var genre in parentGenres)
                genre.AddChildren(this);
        }

        public void AddParent(Genre genre)
        {
            this.ParentGenres.Add(genre);
        }
    }
}