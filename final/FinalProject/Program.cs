using System;
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        PointOfSale pointOfSale = new PointOfSale();
        string menuChoice = null;

        do{
            Console.Clear();
            pointOfSale.DisplayMenu();
            Console.WriteLine("Select one option or 0 to quit:\n");
            menuChoice = Console.ReadLine();

            switch(menuChoice){

                //  New Cart
                case "1":
                    pointOfSale.LoadNewCart();
                    break;
                //  Check Item Price
                case "2":
                    
                    break;
                    //  Add Item
                case "3":
                    
                    break;
                    //  Check Item Price
                case "4":
                    
                    break;

            }


        }while(menuChoice != "0");

        Console.Clear();

    }
}