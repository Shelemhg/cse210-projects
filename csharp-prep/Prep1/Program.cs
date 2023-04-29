using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        string userName = Console.ReadLine();
        Console.WriteLine("What is your last name? ");
        string userLastName = Console.ReadLine();
        Console.WriteLine("Your name is " + userLastName + ", " + userName + " " + userLastName + ".");
    }
}