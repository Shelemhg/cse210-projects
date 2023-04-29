using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What's your magic number? ");
        // int number = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        int number = rnd.Next(1, 100);
        Console.WriteLine("What's your guess? ");
        int guess = int.Parse(Console.ReadLine());

        do{
            if (guess > number){
                Console.WriteLine("Lower");
            }
            else {
                Console.WriteLine("Higher");
            }
            Console.WriteLine("What's your guess? ");
            guess = int.Parse(Console.ReadLine());
        }
        while (guess != number);

        Console.WriteLine("You guessed it!");
        
    }
}