//  - - - FRACTIONS PROGRAM  - Constructors Practice

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        

        Fraction frac = new Fraction();
        Fraction frac2 = new Fraction(2);
        Fraction frac3 = new Fraction(2, 4);

        Console.WriteLine(frac3._top);
        Console.WriteLine(frac3._bottom);

    }
}