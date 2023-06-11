/*
Exceeds core requirements

1. All the inputs are fool proof. As they have data validation and can take: strings, negative numbers and positive numbers. But the program will only continue if a positive int was entered.

2. All the animations and countdowns show on the console without an annoying cursor right next to them. This for clear reading.

3.The program keeps track of how many activities were performed.

4.A precise way to count the time spent on the activities is implemented regardless of the time input, the activity let you finish and counts that time.

*/




using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Activity activity1 = new Activity();
        
        
        string input = null;
        do{
            Console.Clear();
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine("-    M I N D F U L N E S S    -");
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine("1. Breathing activity");
            Console.WriteLine("2. Reflecting activity");
            Console.WriteLine("3. Listing activity");
            Console.WriteLine(". . . . . . . . . . . .");
            Console.WriteLine("4. Exit\n");
            Console.WriteLine("Select a choice from the menu:");
            input = Console.ReadLine();

            switch (input){
                case "1":
                    BreathingActivity breathingActivity1 = new BreathingActivity();
                    breathingActivity1.RunBreathing();
                    break;

                case "2":
                    ReflectionActivity reflexionActivity1 = new ReflectionActivity();
                    reflexionActivity1.RunReflection();                
                    break;

                case "3":
                    ListingActivity listingActivity1 = new ListingActivity();
                    listingActivity1.RunListing(); 
                    break;

                case "4":
                    break;
            }

        }while(input != "4");
    }
}