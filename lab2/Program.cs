using System;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rock = new Genre("Rock");
            var AltRock = new SubGenre("Alt Rock", Rock);
            var FallOutBoy = new Artist("Fall Out Boy", AltRock);
            var SaveRockAndRoll = new Album("Save Rock and Roll", 2013, FallOutBoy);
            
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, SaveRockAndRoll,"The Phoenix"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, SaveRockAndRoll,"Alone Together"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, SaveRockAndRoll,"The Mighty Fall"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, SaveRockAndRoll,"Death Valley"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, SaveRockAndRoll,"Just One Yesterday"));
            
            var AmBeautyAmPsycho = new Album("American Beauty / American Psycho", 2014, FallOutBoy);
            
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Irresistible"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Centuries"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Uma Thurman"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho ,"Novocaine"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Immortals"));
            
            FallOutBoy.AddAlbum(SaveRockAndRoll);
            FallOutBoy.AddAlbum(AmBeautyAmPsycho);
            
            //Console.WriteLine(AmBeautyAmPsycho.Artist.Albums[0].Name);
            
            var Catalog = new Catalog("First Catalog");
            Catalog.AddAlbum(SaveRockAndRoll);
            Catalog.AddAlbum(AmBeautyAmPsycho);
            
            var Pop = new Genre("Pop");
            var DemiLovato = new Artist("Demi Lovato", Pop);
            var Confident = new Album("Confident", 2015, DemiLovato);
            
            Confident.AddTrack(new Track(DemiLovato, Confident, "Confident"));
            Confident.AddTrack(new Track(DemiLovato, Confident,"Kingdom Come"));
            Confident.AddTrack(new Track(DemiLovato, Confident,"Old Ways"));
            
            DemiLovato.AddAlbum(Confident);
            Catalog.AddAlbum(Confident);
            
            var TheBestOfAll = new TrackCollection("The Best Of All");
            TheBestOfAll.AddTrack(new Track(DemiLovato, Confident,"Confident"));
            TheBestOfAll.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Immortals"));
            TheBestOfAll.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Irresistible"));
            TheBestOfAll.AddTrack(new Track(FallOutBoy, AmBeautyAmPsycho,"Centuries"));
            
            Catalog.AddTrackCollection(TheBestOfAll);
            
            Search search = new Search();
            search.SearchArtists(Catalog);
            search.SearchAlbums(Catalog);
            search.SearchSongWithGenre(Catalog, Pop);
            search.SearchArtistsWithGenre(Catalog, AltRock);
        }
    }
}