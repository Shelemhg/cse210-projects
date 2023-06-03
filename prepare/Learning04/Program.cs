using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("John", "Fractions");

        Console.WriteLine(assignment1.GetSummary());



        MathAssignment assignment2 = new MathAssignment("Pete", "Math", "Section 7.3", "8-19");

        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II by Mary Waters");

        Console.WriteLine(assignment3.GetWritingInformation());
    }
}