using System;
using System.Collections.Generic;

namespace lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle(new Point(3, 4), new Point(5, 10), new Point(9, 8));

            Console.WriteLine(" Binary file ");
            string binPath = @"/Users/anastasia/Desktop/ООП/lab4/lab5/SerializedTriangle.bin";
            BinSerializator bin = new BinSerializator();
            bin.Serialize(binPath, triangle);
            Console.WriteLine(bin.Deserialize(binPath).ToString());

            Console.WriteLine(" Xml file ");
            string xmlPath = @"/Users/anastasia/Desktop/ООП/lab4/lab5/SerializedXml.xml";
            XmlSerializator xml = new XmlSerializator();
            xml.Serialize(xmlPath, triangle);
            Console.WriteLine(xml.Deserialize(xmlPath).ToString());
            
            Console.WriteLine(" Data Base ");
            DBTriangleSaver db = new DBTriangleSaver("localhost", 3306, "triangles", "root", "password");
            db.saveTriangle(triangle);
            List<Triangle> triangles = db.getTriangles();
            foreach (var tr in triangles) Console.WriteLine(tr.ToString());
        }
    }
}