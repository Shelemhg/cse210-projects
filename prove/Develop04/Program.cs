using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity1 = new Activity();
        
        
        string input = null;
        do{
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
                    break;
                case "3":
                    break;
                case "4":
                    input = "4";
                    break;
            }

        }while(input != "4");
    }
}