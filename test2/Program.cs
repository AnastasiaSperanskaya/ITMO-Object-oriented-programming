using System;

namespace test2
{
    class Program
    {
        private static void Main()
        {
            Circle circle1 = new Circle(4, 3.4, 2.5);
            circle1.ShowRadius();
            circle1.ShowCoordinates();
            circle1.ShowArea();
            circle1.ShowPerimeter();
            
            Vector v = new Vector(2, 3);
            circle1.VectorShift(v);
            circle1.ShowCoordinates();
            
            Circle circle = new Circle(4, 2, 7);
            circle.VectorShift(new Vector(1,2));
            circle.ShowCoordinates();
            Console.WriteLine(circle.GetInfo());
        }
    }
}