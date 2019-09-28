using System;
using System.Collections.Generic;

namespace lab1
{
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
}