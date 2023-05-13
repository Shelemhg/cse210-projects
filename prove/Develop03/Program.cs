using System;

class Program
{
    static void Main(string[] args)
    {
                // do{
        //     DisplayMenu();
        // } while(number != 0);
        string selection;
        Console.WriteLine("1. New Entry");

        do {
            Console.WriteLine("       J O U R N A L");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("0. Exit");
            selection = Console.ReadLine();

        } while (selection != "0");
    }
}