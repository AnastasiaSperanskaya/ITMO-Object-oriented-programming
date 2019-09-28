using System;
using System.Collections.Generic;

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
        }

    public class FractionList
        {
            public List<RationalFraction> MyFractions = new List<RationalFraction>();
          
            public FractionList() { }
            
            public int Count => MyFractions.Count;

            public FractionList(List<RationalFraction> list)
            {
                this.MyFractions.AddRange(list);
            }

            public void AddFraction(RationalFraction fraction) {
                MyFractions.Add(fraction);
            }
            
            public RationalFraction this[int i]
            {
                get => MyFractions[i];
                set
                {
                    MyFractions[i] = value;
                }
            }
            public void AddFraction(int m, int n)
            {
                RationalFraction F = new RationalFraction(m, n);
                if(n == 0)
                    Console.WriteLine("Error");
                else
                {
                    MyFractions.Add(F);
                }
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

    public class Polynomial
    {
        public readonly FractionList Coeffs;
        
        public Polynomial(List<RationalFraction> coefs) 
        {
            this.Coeffs = new FractionList(coefs);
        }
        public Polynomial(FractionList coefs)
        {
            this.Coeffs = coefs;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b) {
            var num = Math.Max(a.Coeffs.Count, b.Coeffs.Count);

            var nextCoefs = new List<RationalFraction>(num);

            for (var i = 0; i < num; i++) {
                var coefA = a.Coeffs.Count - i - 1 >= 0 ? a.Coeffs[a.Coeffs.Count - i - 1] : null;
                var coefB = b.Coeffs.Count - i - 1 >= 0 ? b.Coeffs[b.Coeffs.Count - i - 1] : null;

                if(coefA != null && coefB != null)
                    nextCoefs.Add(coefA + coefB);
                else if(coefA != null)
                    nextCoefs.Add(coefA);
                else
                    nextCoefs.Add(coefB);
            }

            nextCoefs.Reverse();

            return new Polynomial(nextCoefs);
        }

        public void WritePolynom()
        {
            var copy = this;
            for(var i = copy.Coeffs.Count - 1; i >= 0; i--)
                Console.Write(copy.Coeffs.MyFractions[i].m + "/" + copy.Coeffs.MyFractions[i].n + " ");
            Console.WriteLine();
            
        }
        
    }
    
    internal class Program
        {
            public static void Main(string[] args)
            {
                RationalFraction F1 = new RationalFraction(1, 2);
                RationalFraction F2 = new RationalFraction(1, 3);
                RationalFraction F3 = F1 + F2;
                Console.WriteLine(F3.m + "/" + F3.n);
                Console.WriteLine();
                
                FractionList List1 = new FractionList();
                List1.AddFraction(1, 3);
                List1.AddFraction(2, 3);
                List1.AddFraction(1, 4);
                List1.AddFraction(2, 4);
                List1.AddFraction(0, 0);
                List1.GetMaxRationalFraction().WriteFraction();
                List1.GetMinRationalFraction().WriteFraction();
                Console.WriteLine(List1.CountGreater(F1));
                Console.WriteLine(List1.CountLower(F1));
                Console.WriteLine();
                
                FractionList List3 = new FractionList();
                List3.AddFraction(1,3);
                List3.AddFraction(2,3);
                List3.AddFraction(2,3);
                Polynomial P1 = new Polynomial(List3);
                P1.WritePolynom();

                FractionList List4 = new FractionList();
                List4.AddFraction(1,3);
                List4.AddFraction(3,3);
                List4.AddFraction(1,2);
                List4.AddFraction(1,2);
                Polynomial P2 = new Polynomial(List4);
                P2.WritePolynom();
                
                Polynomial sum = P1 + P2;
                sum.WritePolynom();
            }
        }
}