using System;
using System.Net;

namespace lab1
{
    internal class Program
        {
            public static void Main(string[] args)
            {
                //чтение из файла
                
                FractionList list = FractionList.Load("/Users/anastasia/Desktop/ООП/lab1/lab1/Fractions.txt");
                list.GetMaxRationalFraction().WriteFraction();
                list.GetMinRationalFraction().WriteFraction();
                Console.WriteLine();
                
                //
                
                RationalFraction f1 = new RationalFraction(1, 2);
                RationalFraction f2 = new RationalFraction(1, 3);
                RationalFraction f3 = f1 + f2;
                Console.WriteLine(f3);
                
                FractionList list1 = new FractionList();
                list1.AddFraction(1, 3);
                list1.AddFraction(2, 3);
                list1.AddFraction(1, 4);
                list1.AddFraction(2, 4);
                list1.AddFraction(0, 0);
                list1.GetMaxRationalFraction().WriteFraction();
                list1.GetMinRationalFraction().WriteFraction();
                Console.WriteLine(list1.CountGreater(f1));
                Console.WriteLine(list1.CountLower(f1));
                Console.WriteLine();

                FractionList list3 = new FractionList();
                list3.AddFraction(1,3);
                list3.AddFraction(2,3);
                list3.AddFraction(2,3);
                Polynomial p1 = new Polynomial(list3);
                p1.WritePolynom();

                FractionList list4 = new FractionList();
                list4.AddFraction(1,3);
                list4.AddFraction(3,3);
                list4.AddFraction(1,2);
                list4.AddFraction(1,2);
                Polynomial p2 = new Polynomial(list4);
                p2.WritePolynom();
                
                Polynomial sum = p1 + p2;
                sum.WritePolynom();
            }
        }
}