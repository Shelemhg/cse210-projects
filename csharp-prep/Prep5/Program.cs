using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome(){
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName(){
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber (){
            Console.WriteLine("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            int squared = SquareNumber(number);
            return squared;
        }

        static int SquareNumber (int number){
            int squared = number * number;
            return squared;
        }

        static void DisplayResult (string name, int squared){            
            Console.WriteLine(name + ", " + "the square of your number is " + squared );
        }
        
        DisplayWelcome();
        string name = PromptUserName();
        int squared = PromptUserNumber();
        DisplayResult(name, squared);
    }
}