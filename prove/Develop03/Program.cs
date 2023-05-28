/*
Exceeding Requirements:


For this program I:


1. Updated the inputs to ENTER, BACKSPACE and ESC as main drivers of the program

2. The program can receive any text and help you memorize it

3. The program contains a "History" of how many words were hidden every round, and what words were hidden. So if in the last attempt to hide more words the user fails, he can just back track and move a step back in 1 click. But not any step, but THE EXACT STEP he took. Meaning the program can take him back all the way until he finds a past point where he felt comfortable reciting.

- Finally, attention to the detail:

The program selects random words to hide OR starts hidding from the begining. Why? Because the words that you memorize first are those at the begining, so we hide them first instead of other words at the end that are harder to memorize.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        string selection = null;
        
        Scripture scripture1 = null;

        do{
            Console.WriteLine("Would you like to add your own scripture? (y/n)(quit):");
            // selection = "n";
            selection = Console.ReadLine();

            
                if (selection.ToLower() == "y"){
                    Console.WriteLine(" Enter the new scripture and hit Enter:");
                    string newScripture = Console.ReadLine();
                    scripture1 = new Scripture(newScripture);
                }
                else if(selection.ToLower() == "n"){
                    scripture1 = new Scripture();              
                }
        }while(selection.ToLower() != "y" && selection.ToLower() != "n");

        Console.Clear();
        scripture1.DisplayScripture();   
        scripture1.DisplayReference();     
        ConsoleKeyInfo input;

        do{
            Console.WriteLine("\nPress:\n\n ENTER - to hide more words\n BACKSPACE - to unhide the last words hidden or \n ESC - to end the program:");
            input = Console.ReadKey();
            
            if(input.Key == ConsoleKey.Enter){
                scripture1.HideWords();
            }
            else if (input.Key == ConsoleKey.Backspace){
                scripture1.UnhideWords();
            }else if (input.Key == ConsoleKey.Escape){
                break;
            }
            Console.Clear();
            scripture1.DisplayScripture();
            
        }while((scripture1._hiddenWordsList.Count() < scripture1._wordCount));

        Console.Clear();
        scripture1.DisplayScripture();        
        Console.WriteLine("\n Thanks for Playing!\n");
    }
}