using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finihsed");
        
        float total;
        total = 0;
        int number = -1;
        float largest = 0;

        List<float> list = new List<float>();
        
        do{
            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());
            list.Add(number);
        } while(number != 0);

        foreach (float item in list){
            total = total + item;
            if (item > largest){
                largest = item;
            }
        }

        float average = total/(list.Count - 1);
        Console.WriteLine("The sum is: " + total);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + largest);
    }
}