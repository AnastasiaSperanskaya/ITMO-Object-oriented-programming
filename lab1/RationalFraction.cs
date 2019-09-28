using System;

namespace lab1
{
    public class RationalFraction
    {
        public int m, n;

        public RationalFraction(int m, int n)
        {
            this.m = m;
            this.n = n;
        }
            
        public static bool operator <(RationalFraction a, RationalFraction b)
        {
            return a.m * b.n < b.m * a.n;
        }
            
        public static bool operator >(RationalFraction a, RationalFraction b)
        {
            return a.m * b.n > b.m * a.n;
        }

        public static RationalFraction operator +(RationalFraction a, RationalFraction b)
        {
            return new RationalFraction(a.m * b.n + a.n * b.m, a.n * b.n);
        }

        public void WriteFraction()
        {
            if(this.m == 0) Console.WriteLine("0");
            else if(this.n == 1) Console.WriteLine(this.m);
            else Console.WriteLine(this.m + "/" + this.n);
        }

        public override string ToString()
        {
            if(this.m == 0) return "0";
            else if(this.n == 1) return this.m.ToString();
            else return $"{this.m}/{this.n}";
        }
    }
}