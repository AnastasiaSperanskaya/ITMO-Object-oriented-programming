using System;
using System.Collections.Generic;

namespace lab1
{
    class RationalFraction
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
        }

    class FractionList
        {
            public List<RationalFraction> MyFractions = new List<RationalFraction>();

            public void AddFraction(int m, int n)
            {
                RationalFraction F = new RationalFraction(m, n);
                MyFractions.Add(F);
            }

            public RationalFraction GetMaxRationalFraction()
            {
                RationalFraction max = null;
                foreach (var F in MyFractions)
                    if (max == null || max < F)
                        max = F;
                return max;
            }
            
            public RationalFraction GetMinRationalFraction()
            {
                RationalFraction min = null;
                foreach (var F in MyFractions)
                    if (min == null || min > F)
                        min = F;
                return min;
            }

            public int CountGreater(RationalFraction fraction)
            {
                var n = 0;
                foreach (var F in MyFractions)
                    if (F > fraction)
                        n++;
                return n;
            }
            
            public int CountLower(RationalFraction fraction)
            {
                var n = 0;
                foreach (var F in MyFractions)
                    if (F < fraction)
                        n++;
                return n;
            }
            
        }

    class Polynomial
    {
        public List<RationalFraction> coeffs;

        public Polynomial PolynomialSum(Polynomial P1, Polynomial P2)
        {
            
        }
        
    }
    
    internal class Program
        {
            public static void Main(string[] args)
            {
                RationalFraction F1 = new RationalFraction(1, 2);
                Console.WriteLine(F1.m + " / " + F1.n);
                
                FractionList List1 = new FractionList();
                List1.AddFraction(1, 3);
                List1.AddFraction(2, 3);
                List1.AddFraction(1, 4);
                List1.AddFraction(2, 4);
                Console.WriteLine(List1.GetMaxRationalFraction().m + " / " + List1.GetMaxRationalFraction().n);
                Console.WriteLine(List1.GetMinRationalFraction().m + " / " + List1.GetMinRationalFraction().n);
                Console.WriteLine(List1.CountGreater(F1));
                Console.WriteLine(List1.CountLower(F1));

            }
        }
}