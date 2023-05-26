/*
Exceeding Requirements:


For this program I:


1. Added the posibility for the user to type any scripture or text he wishes and then work with it to run the program.

2. The program can take both scriptures or random texts.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        
        string selection;
        Console.WriteLine("Would you like to add your own scripture? (y/n)(quit):");
        // selection = Console.ReadLine();
        selection = "n";

        Scripture scripture1 = null;
        
            if (selection.ToLower() == "y"){
                Console.WriteLine(" Enter the new scripture and hit Enter:");
                string newScripture = Console.ReadLine();
                scripture1 = new Scripture(newScripture);
            }
            else if(selection.ToLower() == "n"){
                scripture1 = new Scripture();                
            }
        Console.Clear();
        scripture1.DisplayScripture();
        
        ConsoleKeyInfo input;

        do{
            
            Console.WriteLine("\nPress Enter to hide more words, or quit to finish:");
            // key = Console.ReadLine();
            // input = string.Empty;
            input = Console.ReadKey();
            
            if(input.Key == ConsoleKey.Enter){
                scripture1.HideWords();
                // scripture1.DisplayScripture();
            }
            else if (input.Key == ConsoleKey.Backspace){
                // Console.WriteLine("BACKSPACE");
                scripture1.unhideWords();
                // scripture1.DisplayScripture();
            }else if (input.Key == ConsoleKey.Escape){
                break;
            }
            // Console.Clear();
            scripture1.DisplayScripture();
            // Console.WriteLine("\n\nHIDDEN words: " + scripture1._hiddenWordsList.Count() + " < Visible: " + scripture1._words.Count());

        // }while((scripture1._visibleWords > 0) && (key != "quit"));
        }while((scripture1._hiddenWordsList.Count() < scripture1._words.Count()));
        // }while(true);
        // Console.WriteLine("KEY" +input.Key);



        Console.Clear();
        scripture1.DisplayScripture();        
        Console.WriteLine("\n Thanks for Playing!\n");
    }
}