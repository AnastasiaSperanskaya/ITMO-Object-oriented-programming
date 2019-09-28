using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;

namespace lab1
{
    public class FractionList
    {
        public List<RationalFraction> MyFractions = new List<RationalFraction>();
        public RationalFraction min = null;
        public RationalFraction max = null;
          
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
            RationalFraction f = new RationalFraction(m, n);
            if(n == 0)
                Console.WriteLine("Error");
            else
            {
                MyFractions.Add(f);
            }
        }
        public RationalFraction GetMaxRationalFraction()
        {
            foreach (var f in MyFractions)
                if (this.max == null || this.max < f)
                    this.max = f;
            return this.max;
        }
            
        public RationalFraction GetMinRationalFraction()
        {
            foreach (var f in MyFractions)
                if (this.min == null || this.min > f)
                    this.min = f;
            return this.min;
        }

        public int CountGreater(RationalFraction fraction)
        {
            var n = 0;
            foreach (var f in MyFractions)
                if (f > fraction)
                    n++;
            return n;
        }
            
        public int CountLower(RationalFraction fraction)
        {
            var n = 0;
            foreach (var f in MyFractions)
                if (f < fraction)
                    n++;
            return n;
        }
        
        public static FractionList Load(string path)
        {
            FractionList list = new FractionList();
            
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split('/');

                    if (lines.Length != 2) continue;

                    int num, denum;
                    if (!Int32.TryParse(lines[0].Trim(), out num) ||
                        !Int32.TryParse(lines[1].Trim(), out denum)) continue;

                    try
                    {
                        if(denum != 0)
                            list.AddFraction(new RationalFraction(num, denum));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid fraction format: num = {num} , denum = {denum}");
                    }
                }
            }

            return list;
        }
    }
}