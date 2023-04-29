using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = Convert.ToInt32(Console.ReadLine());
        string letter = "";

        if (grade >= 90){
            letter = "A";           
        }
        else if (grade >= 80) {
            letter = "B";
        }
        else if (grade >= 70) {
            letter = "C";
        }
        else if (grade >= 60) {
            letter = "D";
        }
        else{
            letter = "F";
        }

         Console.WriteLine("Your grade is " + letter);

        if (letter == "F"){
            Console.WriteLine("Let's try again next time!");
        }
        else {
            Console.WriteLine("Congratulations, you passed!");
        }
        
    }
}