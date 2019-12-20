using System;
using lab3.Exceptions;

namespace lab3
{
    internal class Program {
        public static void Main(string[] args)
        {
            IniFileData iniFileData = Parser.ParseFile("/Users/anastasia/Desktop/ООП/lab3/lab3/Example.ini");

            Console.WriteLine(iniFileData["ADC_DEV"].GetFloat("BufferLenSeconds"));
            Console.WriteLine(iniFileData["NCMD"].GetInt("TidPacketVersionForTidControlCommand"));
            Console.WriteLine(iniFileData["ADC_DEV"].GetString("Driver"));
            try
            {
                Console.WriteLine(iniFileData["ADC_DEV"].GetString("fnjrkg")); //exception test
            }
            catch (KeyNotFound e)
            {
                Console.WriteLine("fnjrkg not found");
            }
          
        }
    }
}