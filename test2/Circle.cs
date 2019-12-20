using System;

namespace test2
{
    public class Circle
    {
        private  readonly double _radius;
        private readonly Point _coordinates;

        public Circle(double radius, double x, double y)
        {
            this._radius = radius;
            Point point = new Point(x, y);
            this._coordinates = point;
        }

        private Point GetCoordinates()
        {
            return this._coordinates;
        }
        private double GetRadius()
        {
            return this._radius;
        }

        public string GetInfo()
        {
            return "Radius: " + GetRadius() + "\nCoordinates: (" + GetCoordinates().X + ";" + GetCoordinates().Y + ")";
        }
        public double GetArea()
        {
            return Math.PI * this._radius * this._radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * this._radius;
        }
        public void ShowRadius()
        {
            Console.WriteLine("Radius of the circle is: " + this.GetRadius());
        }

        public void ShowCoordinates()
        {
            Console.WriteLine("Coordinates of the circle are: " + "(" + this.GetCoordinates().X + " ; " + this.GetCoordinates().Y + ")");
        }

        public void ShowArea()
        {
            Console.WriteLine("The area of the circle is: " + GetArea());
        }
        
        public void ShowPerimeter()
        {
            Console.WriteLine("The perimeter of the circle is: " + GetPerimeter());
        }

        public void VectorShift(Vector v)
        {
            this._coordinates.X = this._coordinates.X + v.X;
            this._coordinates.Y = this._coordinates.Y + v.Y;
        }
    }
}