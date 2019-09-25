using System;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var AltRock = new Genre("Alt Rock");
            var FallOutBoy = new Artist("Fall Out Boy", AltRock);
            var SaveRockAndRoll = new Album("Save Rock and Roll", 2013, FallOutBoy);
            
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, "The Phoenix"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, "Alone Together"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, "The Mighty Fall"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, "Death Valley"));
            SaveRockAndRoll.AddTrack(new Track(FallOutBoy, "Just One Yesterday"));
            
            var AmBeautyAmPsycho = new Album("American Beauty / American Psycho", 2014, FallOutBoy);
            
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, "Irresistible"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, "Centuries"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, "Uma Thurman"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, "Novocaine"));
            AmBeautyAmPsycho.AddTrack(new Track(FallOutBoy, "Immortals"));
            
            FallOutBoy.AddAlbum(SaveRockAndRoll);
            FallOutBoy.AddAlbum(AmBeautyAmPsycho);
            
            //Console.WriteLine(AmBeautyAmPsycho.Artist.Albums[0].Name);
            
            var Catalog = new Catalog();
            Catalog.AddAlbum(SaveRockAndRoll);
            Catalog.AddAlbum(AmBeautyAmPsycho);
        }
    }
}