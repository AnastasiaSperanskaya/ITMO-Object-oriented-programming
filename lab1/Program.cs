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

            public int GetAmount()
            {
                int n = 0;
                foreach (var F in MyFractions)
                {
                    n++;
                }
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
        public Polynomial PolynomialSum(Polynomial P1, Polynomial P2)
        {
            var max = Math.Max(P1.Coeffs.GetAmount(), P2.Coeffs.GetAmount());

            var sum = new List<RationalFraction>(max);

            for (var i = 0; i < max; i++) {
                var coeff1 = P1.Coeffs.GetAmount() - i - 1 >= 0 ? P1.Coeffs[P1.Coeffs.GetAmount() - i - 1] : null;
                var coeff2 = P2.Coeffs.GetAmount() - i - 1 >= 0 ? P2.Coeffs[P2.Coeffs.GetAmount() - i - 1] : null;

                if(coeff1 != null && coeff2 != null)
                    sum.Add(coeff1 + coeff1);
                else if(coeff1 != null)
                    sum.Add(coeff1);
                else
                    sum.Add(coeff2);
            }

            return new Polynomial(sum);
        }

        public void WritePolynom()
        {
            for(var i = 0; i < this.Coeffs.GetAmount(); i++)
                Console.Write(this.Coeffs.MyFractions[i].m + "/" + this.Coeffs.MyFractions[i].n + " ");
            
        }
        
    }
    
    internal class Program
        {
            public static void Main(string[] args)
            {
                RationalFraction F1 = new RationalFraction(1, 2);
                Console.WriteLine(F1.m + "/" + F1.n);
                
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
                
                FractionList List3 = new FractionList();
                List3.AddFraction(1,2);
                Polynomial P1 = new Polynomial(List3);

                FractionList List4 = new FractionList();
                List4.AddFraction(1,2);
                Polynomial P2 = new Polynomial(List4);

                FractionList List2 = new FractionList();
                Polynomial sum = new Polynomial(List2).PolynomialSum(P2, P1);
                sum.WritePolynom();
            }
        }
}